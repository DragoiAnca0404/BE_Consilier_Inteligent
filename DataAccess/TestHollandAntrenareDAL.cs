using BE_ConsilierInteligent.DataAccess.Entities;
using BE_ConsilierInteligent.DataAccess.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace BE_ConsilierInteligent.DataAccess
{
    public class TestHollandAntrenareDAL: ControllerBase
    {

        private readonly ITransformer _model;
        private MulticlassClassificationMetrics _metrics;
        private readonly MLContext _mlContext = new MLContext();
        private IDataView _trainingDataView;

        public TestHollandAntrenareDAL()
        {
            _model = TrainModel();
        }

        public ITransformer TrainModel()
        {
            var _context = new ConsilierContext();

            var trainingData = _context.Solutii_Training
                .Select(st => new SubjectPredictionDataHolland
                {
                    Intrebare1 = st.intrebare_1,
                    Intrebare2 = st.intrebare_2,
                    Intrebare3 = st.intrebare_3,
                    Intrebare4 = st.intrebare_4,
                    Intrebare5 = st.intrebare_5,
                    Intrebare6 = st.intrebare_6,
                    Intrebare7 = st.intrebare_7,
                    Intrebare8 = st.intrebare_8,
                    Intrebare9 = st.intrebare_9,
                    Intrebare10 = st.intrebare_10,
                    Intrebare11 = st.intrebare_11,
                    Intrebare12 = st.intrebare_12,
                    Label = st.id_solutie
                })
                .ToList();

            _trainingDataView = _mlContext.Data.LoadFromEnumerable(trainingData);

            var pipeline = _mlContext.Transforms.Concatenate("Features", nameof(SubjectPredictionDataHolland.Intrebare1), nameof(SubjectPredictionDataHolland.Intrebare2), nameof(SubjectPredictionDataHolland.Intrebare3), nameof(SubjectPredictionDataHolland.Intrebare4), nameof(SubjectPredictionDataHolland.Intrebare5), nameof(SubjectPredictionDataHolland.Intrebare6), nameof(SubjectPredictionDataHolland.Intrebare7), nameof(SubjectPredictionDataHolland.Intrebare8), nameof(SubjectPredictionDataHolland.Intrebare9), nameof(SubjectPredictionDataHolland.Intrebare10), nameof(SubjectPredictionDataHolland.Intrebare11), nameof(SubjectPredictionDataHolland.Intrebare12))
                .AppendCacheCheckpoint(_mlContext)
                .Append(_mlContext.Transforms.Conversion.MapValueToKey("Label"))
                .Append(_mlContext.MulticlassClassification.Trainers.NaiveBayes(labelColumnName: "Label"));

            var model = pipeline.Fit(_trainingDataView);
            EvaluateModel(_trainingDataView, model);

            return model;
        }



        public async Task<IActionResult> Predict([FromQuery] float[] raspunsuri)
        {
            var _context = new ConsilierContext();


            // Se crează un obiect nou de tip SubjectPredictionDataHolland pe baza array-ului de raspunsuri
            var data = new SubjectPredictionDataHolland
            {
                Intrebare1 = raspunsuri[0],
                Intrebare2 = raspunsuri[1],
                Intrebare3 = raspunsuri[2],
                Intrebare4 = raspunsuri[3],
                Intrebare5 = raspunsuri[4],
                Intrebare6 = raspunsuri[5],
                Intrebare7 = raspunsuri[6],
                Intrebare8 = raspunsuri[7],
                Intrebare9 = raspunsuri[8],
                Intrebare10 = raspunsuri[9],
                Intrebare11 = raspunsuri[10],
                Intrebare12 = raspunsuri[11]
            };

            var predictionEngine = _mlContext.Model.CreatePredictionEngine<SubjectPredictionDataHolland, CoursesPredictionHolland>(_model);

            var result = predictionEngine.Predict(data);

            int coursesValue = Convert.ToInt32(result.Courses);

            var result_two = _context.Solutie
                                .Where(w => w.id_solutie.Equals(coursesValue))
                                .Select(y => new { denumire_solutie = y.denumire_solutie })
                                .ToList();

            return Ok(result_two);
        }
        private void EvaluateModel(IDataView trainingDataView, ITransformer model)
        {
            var predictions = model.Transform(trainingDataView);
            _metrics = _mlContext.MulticlassClassification.Evaluate(predictions);
        }


        public async Task<IActionResult> GetMetrics()
          {
              if (_metrics == null)
              {
                  return NotFound("Metrics are not available. Model might not be trained yet.");
              }

              var metricsData = new
              {
                  _metrics.LogLoss,
                  _metrics.LogLossReduction,
                  _metrics.MacroAccuracy,
                  _metrics.MicroAccuracy,
                  _metrics.TopKAccuracy,
                  _metrics.TopKPredictionCount
              };

              return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(metricsData));
          }


    }

    public class SubjectPredictionDataHolland
    {
        [LoadColumn(0)]
        public float Intrebare1 { get; set; }

        [LoadColumn(1)]
        public float Intrebare2 { get; set; }

        [LoadColumn(2)]
        public float Intrebare3 { get; set; }

        [LoadColumn(3)]
        public float Intrebare4 { get; set; }

        [LoadColumn(4)]
        public float Intrebare5 { get; set; }

        [LoadColumn(5)]
        public float Intrebare6 { get; set; }

        [LoadColumn(6)]
        public float Intrebare7 { get; set; }

        [LoadColumn(7)]
        public float Intrebare8 { get; set; }

        [LoadColumn(8)]
        public float Intrebare9 { get; set; }

        [LoadColumn(9)]
        public float Intrebare10 { get; set; }

        [LoadColumn(10)]
        public float Intrebare11 { get; set; }

        [LoadColumn(11)]
        public float Intrebare12 { get; set; }

        [LoadColumn(12)]
        [ColumnName("Label")]
        public float Label { get; set; }
    }

    public class CoursesPredictionHolland
    {
        [ColumnName("PredictedLabel")]
        public uint Courses;
    }
}
