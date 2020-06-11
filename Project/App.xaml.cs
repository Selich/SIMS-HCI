using System.Configuration;
using Project.Repositories;
using System.Windows;
using Project.Repositories.CSV.Converter;
using Project.Repositories.CSV.Stream;
using Project.Model;
using Project.Repositories.Sequencer;
using Project.Services;
using Project.Controllers;
using Project.Views.Model;
using Controller;
using Project.Views.Converters;

namespace Project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static string PATIENT_FILEPATH = ConfigurationManager.AppSettings["PatientPath"].ToString();
        private static string QUESTION_FILEPATH = ConfigurationManager.AppSettings["QuestionPath"].ToString();
        private static string DELIMITER = ConfigurationManager.AppSettings["DelimiterValue"].ToString();
        private static string DATETIME_FORMAT = ConfigurationManager.AppSettings["DateTimeFormat"].ToString();


        private static string REPORT_ROOM_PATH = ConfigurationManager.AppSettings["ReportRoomPath"].ToString();

        public App()
        {
            // Converters
            var patientConverter = new PatientConverter();
            var questionConverter = new QuestionConverter(patientConverter);

            // Repositories
            var patientRepository = new PatientRepository(new CSVStream<Patient>(PATIENT_FILEPATH, new PatientCSVConverter(DELIMITER, DATETIME_FORMAT)), new LongSequencer());
            var questionRepository = new QuestionRepository(new CSVStream<Question>(QUESTION_FILEPATH, new QuestionCSVConverter(DELIMITER, DATETIME_FORMAT)), new LongSequencer());

            // Services
            var patientService = new PatientService(patientRepository);
            var questionService = new QuestionService(questionRepository);
            var reportService = new ReportService();

            // Controllers
            PatientController = new PatientController(patientService, patientConverter);
            QuestionController = new QuestionController(questionService, questionConverter, patientConverter);
            ReportController = new ReportController();
        }



        public IController<PatientDTO, long> PatientController { get; private set; }
        public ReportController ReportController { get; private set; }
        public IController<QuestionDTO, long> QuestionController { get; private set; }
    }
}
