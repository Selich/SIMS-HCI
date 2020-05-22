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

namespace Project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string PATIENT_FILE = "../../Resources/Data/patients.csv";
        private const string DOCTOR_FILE = "../../Resources/Data/doctors.csv";
        private const string SECRETARY_FILE = "../../Resources/Data/secretaries.csv";
        private const string DIRECTOR_FILE = "../../Resources/Data/directors.csv";
        private const string APPOINTMENT_FILE = "../../Resources/Data/appointments.csv";
        private const string ADDRESS_FILE = "../../Resources/Data/adresses.csv";
        private const string EQUIPMENT_FILE = "../../Resources/Data/equipment.csv";
        private const string ORDER_FILE = "../../Resources/Data/orders.csv";
        private const string QUESTION_FILE = "../../Resources/Data/questions.csv";
        private const string CSV_DELIMITER = ",";

        private const string DATETIME_FORMAT = "dd.MM.yyyy.";

        public App()
        {
            // Repositories
            var patientRepository = new PatientRepository(new CSVStream<Account>(ACCOUNT_FILE, new AccountCSVConverter(CSV_DELIMITER)), new LongSequencer());



            var clientRepository = new ClientRepository( new CSVStream<Client>(CLIENT_FILE, new ClientCSVConverter(CSV_DELIMITER, DATETIME_FORMAT)), new LongSequencer(), accountRepository);
            var loanRepository = new LoanRepository( new CSVStream<Loan>(LOAN_FILE, new LoanCSVConverter(CSV_DELIMITER, DATETIME_FORMAT)), new LongSequencer(), clientRepository);
            var transactionRepository = new TransactionRepository( new CSVStream<Transaction>(TRANSACTION_FILE, new TransactionCSVConverter(CSV_DELIMITER, DATETIME_FORMAT)), new LongSequencer(), clientRepository);

            // Services
            var accountService = new AccountService(accountRepository);
            var clientService = new ClientService(clientRepository, accountService);
            var loanService = new LoanService(loanRepository, clientService);
            var transactionService = new TransactionService(transactionRepository, clientService);

            // Controllers
            AccountController = new AccountController(accountService);
            ClientController = new ClientController(clientService);
            LoanController = new LoanController(loanService);
            TransactionController = new TransactionController(transactionService);
        }

        public IController<Account, long> AccountController { get; private set; }
        public IController<Client, long> ClientController { get; private set; }
        public IController<Loan, long> LoanController { get; private set; }
        public IController<Transaction, long> TransactionController { get; private set; }
    }
}
