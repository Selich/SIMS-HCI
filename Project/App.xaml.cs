using System;
using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.Generic;
using System.Configuration;
using Project.Repositories;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Project.Repositories.CSV.Converter;
using System.Configuration;
using Project.Repositories.CSV.Stream;
using Project.Model;
using Project.Repositories.Sequencer;
using Project.Services;
using Project.Controllers;

namespace Project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // TODO: Treba da se nalazi u conf fajlu
        //private const string PATIENT_FILE = System.Configuration.ConfigurationManager.AppSettings["PatientPath"].ToString();

        private const string DATETIME_FORMAT = "dd.MM.yyyy.";

        public App()
        {
            // Repositories
            var patientRepository = new PatientRepository(new CSVStream<Patient>("../../Resources/Data/patients.csv", new PatientCSVConverter(",", DATETIME_FORMAT)), new LongSequencer());

            // Services
            var patientService = new PatientService(patientRepository);

            // Controllers
            PatientController = new PatientController(patientService);
        }

        public IController<Patient, long> PatientController { get; private set; }
    }
}
