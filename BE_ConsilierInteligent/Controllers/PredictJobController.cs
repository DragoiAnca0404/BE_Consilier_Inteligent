using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.ML;
using Microsoft.ML.Data;
using SubjectPrediction;


namespace BE_ConsilierInteligent.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PredictJobController : ControllerBase
    {
        private readonly string _modelPath = Path.Combine(Environment.CurrentDirectory, "C:\\Users\\anca_\\Desktop\\disertatie\\aplicatie\\BE_ConsilierInteligent\\BE_ConsilierInteligent\\Data\\model.zip");
        private readonly MLContext _mlContext = new MLContext();
        private readonly IDataView _trainingDataView;
        private readonly ITransformer _model;
        private MulticlassClassificationMetrics _metrics;

        public PredictJobController()
        {
            _trainingDataView = _mlContext.Data.LoadFromTextFile<SubjectPredictionData>(path: "C:\\Users\\anca_\\Desktop\\disertatie\\aplicatie\\BE_ConsilierInteligent\\BE_ConsilierInteligent\\Data\\stud_training.csv", hasHeader: true, separatorChar: ',');
            _model = BuildModel();
        }

        private ITransformer BuildModel()
        {
            string featuresColumnName = "Features";

            var dataPreparationPipeline = _mlContext.Transforms.Conversion.MapValueToKey("Label")
              .Append(_mlContext.Transforms.Concatenate(featuresColumnName,
                  "Drawing", "Dancing", "Singing", "Sports", "VideoGame", "Acting",
                  "Travelling", "Gardening", "Animals", "Photography", "Teaching",
                  "Exercise", "Coding", "ElectricityComponents", "MechanicParts",
                  "ComputerParts", "Researching", "Architecture", "HistoricCollection",
                  "Botany", "Zoology", "Physics", "Accounting", "Economics", "Sociology",
                  "Geography", "Psycology", "History", "Science", "BussinessEducation",
                "Chemistry", "Mathematics", "Biology", "Makeup", "Designing", "ContentWriting",
                  "Crafting", "Literature", "Reading", "Cartooning", "Debating", "Asrtology",
                  "Hindi", "French", "English", "Urdu", "OtherLanguage", "SolvingPuzzles",
                  "Gymnastics", "Yoga", "Doctor", "Cycling",
                  "Knitting", "Director", "Journalism", "Bussiness", "ListeningMusic"))
              .AppendCacheCheckpoint(_mlContext);

            var naiveBayesMultiClassTrainer = dataPreparationPipeline
                .Append(_mlContext.MulticlassClassification.Trainers.NaiveBayes(labelColumnName: "Label", featureColumnName: featuresColumnName))
                .Append(_mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            var model = naiveBayesMultiClassTrainer.Fit(_trainingDataView);
          
            EvaluateModel(_trainingDataView, model);


            return model;
        }

        private void EvaluateModel(IDataView trainingDataView, ITransformer model)
        {
            var predictions = model.Transform(trainingDataView);
            _metrics = _mlContext.MulticlassClassification.Evaluate(predictions);
        }


        [HttpGet("metrici")]
        public ActionResult<string> GetMetrics()
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

        [HttpGet("predict")]
        public ActionResult<CoursesPrediction> Predict([FromQuery] string passions)
        {
            // Split pasiuni string intr-un vector
            string[] passionArray = passions.Split(',');

            // Creeare obiect SubjectPredictionData obiect si initializez toate pasiunile cu 0
            SubjectPredictionData predictionData = new SubjectPredictionData();

            // Pointez cu 1 unde identific pasiunea
            foreach (string passion in passionArray)
            {
                typeof(SubjectPredictionData).GetProperty(passion)?.SetValue(predictionData, 1);
            }

            //Predictia
            var predictionEngine = _mlContext.Model.CreatePredictionEngine<SubjectPredictionData, CoursesPrediction>(_model);
            var result = predictionEngine.Predict(predictionData);

            return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        [HttpGet("save-model")]
        public ActionResult SaveModel()
        {
            using (var fileStream = new FileStream(_modelPath, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                _mlContext.Model.Save(_model, _trainingDataView.Schema, fileStream);
                Console.WriteLine();
                Console.WriteLine("Trained model");
                Console.WriteLine("-----------------");
            }

            return Ok();
        }
    }
}