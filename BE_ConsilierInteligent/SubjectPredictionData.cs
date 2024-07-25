using Microsoft.ML.Data;

namespace SubjectPrediction
{
    public class SubjectPredictionData
    {
        [LoadColumn(0)]
        public float Drawing { get; set; }
        [LoadColumn(1)]
        public float Dancing { get; set; }
        [LoadColumn(2)]
        public float Singing { get; set; }
        [LoadColumn(3)]
        public float Sports { get; set; }
        [LoadColumn(4)]
        public float VideoGame { get; set; }
        [LoadColumn(5)]
        public float Acting { get; set; }
        [LoadColumn(6)]
        public float Travelling { get; set; }
        [LoadColumn(7)]
        public float Gardening { get; set; }
        [LoadColumn(8)]
        public float Animals { get; set; }
        [LoadColumn(9)]
        public float Photography { get; set; }
        [LoadColumn(10)]
        public float Teaching { get; set; }
        [LoadColumn(11)]
        public float Exercise { get; set; }
        [LoadColumn(12)]
        public float Coding { get; set; }
        [LoadColumn(13)]
        public float ElectricityComponents { get; set; }
        [LoadColumn(14)]
        public float MechanicParts { get; set; }
        [LoadColumn(15)]
        public float ComputerParts { get; set; }
        [LoadColumn(16)]
        public float Researching { get; set; }
        [LoadColumn(17)]
        public float Architecture { get; set; }
        [LoadColumn(18)]
        public float HistoricCollection { get; set; }
        [LoadColumn(19)]
        public float Botany { get; set; }
        [LoadColumn(20)]
        public float Zoology { get; set; }
        [LoadColumn(21)]
        public float Physics { get; set; }
        [LoadColumn(22)]
        public float Accounting { get; set; }
        [LoadColumn(23)]
        public float Economics { get; set; }
        [LoadColumn(24)]
        public float Sociology { get; set; }
        [LoadColumn(25)]
        public float Geography { get; set; }
        [LoadColumn(26)]
        public float Psycology { get; set; }
        [LoadColumn(27)]
        public float History { get; set; }
        [LoadColumn(28)]
        public float Science { get; set; }
        [LoadColumn(29)]
        public float BussinessEducation { get; set; }
        [LoadColumn(30)]
        public float Chemistry { get; set; }
        [LoadColumn(31)]
        public float Mathematics { get; set; }
        [LoadColumn(32)]
        public float Biology { get; set; }
        [LoadColumn(33)]
        public float Makeup { get; set; }
        [LoadColumn(34)]
        public float Designing { get; set; }
        [LoadColumn(35)]
        public float ContentWriting { get; set; }
        [LoadColumn(36)]
        public float Crafting { get; set; }
        [LoadColumn(37)]
        public float Literature { get; set; }
        [LoadColumn(38)]
        public float Reading { get; set; }
        [LoadColumn(39)]
        public float Cartooning { get; set; }
        [LoadColumn(40)]
        public float Debating { get; set; }
        [LoadColumn(41)]
        public float Asrtology { get; set; }
        [LoadColumn(42)]
        public float Hindi { get; set; }
        [LoadColumn(43)]
        public float French { get; set; }
        [LoadColumn(44)]
        public float English { get; set; }
        [LoadColumn(45)]
        public float Urdu { get; set; }
        [LoadColumn(46)]
        public float OtherLanguage { get; set; }
        [LoadColumn(47)]
        public float SolvingPuzzles { get; set; }
        [LoadColumn(48)]
        public float Gymnastics { get; set; }
        [LoadColumn(49)]
        public float Yoga { get; set; }
        [LoadColumn(50)]
        public float Engeeniering { get; set; }
        [LoadColumn(51)]
        public float Doctor { get; set; }
        [LoadColumn(52)]
        public float Pharmisist { get; set; }
        [LoadColumn(53)]
        public float Cycling { get; set; }
        [LoadColumn(54)]
        public float Knitting { get; set; }
        [LoadColumn(55)]
        public float Director { get; set; }
        [LoadColumn(56)]
        public float Journalism { get; set; }
        [LoadColumn(57)]
        public float Bussiness { get; set; }
        [LoadColumn(58)]
        public float ListeningMusic { get; set; }
        [LoadColumn(59)]
        public string Label { get; set; }

    }
    public class CoursesPrediction
    {
        [ColumnName("PredictedLabel")]
        public string Courses;
    }
}
