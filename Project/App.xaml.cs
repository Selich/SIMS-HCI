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
using Model;
using Project.Repositories.CSV.Stream;
using Project.Model;
using Project.Repositories.Sequencer;

namespace Project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // TODO: Treba da se nalazi u conf fajlu
        private const string PATIENT_FILE = ConfigurationSettings.AppSettings["PatientPath"].ToString();

        private const string DATETIME_FORMAT = "dd.MM.yyyy.";

        public App()
        {
            // Repositories
            var patientRepository = new PatientRepository(new CSVStream<Patient>(PATIENT_FILE, new AddressCSVConverter(CSV_DELIMITER)), new LongSequencer());

            // Services
            //var patientService = new ClientService(clientRepository, accountService);

            // Controllers
            //ClientController = new ClientController(clientService);
        }

        //public IController<Account, long> AccountController { get; private set; }
        //public IController<Client, long> ClientController { get; private set; }
    }
}
