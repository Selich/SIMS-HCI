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

namespace Project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // TODO: Treba da se nalazi u conf fajlu
        private static string PATIENT_FILEPATH = ConfigurationManager.AppSettings["PatientPath"].ToString();
        private static string DELIMITER = ConfigurationManager.AppSettings["DelimiterValue"].ToString();
        private static string DATETIME_FORMAT = ConfigurationManager.AppSettings["DateTimeFormat"].ToString();


        public App()
        {
            // Repositories
            var patientRepository = new PatientRepository(new CSVStream<Patient>(PATIENT_FILEPATH, new PatientCSVConverter(DELIMITER, DATETIME_FORMAT)), new LongSequencer());

            // Services
            var patientService = new PatientService(patientRepository);

            // Controllers
            PatientController = new PatientController(patientService);
        }



        public IController<PatientDTO, long> PatientController { get; private set; }
    }
}
