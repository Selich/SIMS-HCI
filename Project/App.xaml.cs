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
using iTextSharp.text;
using System.Collections.Generic;
using Project.Views.Secretary;
using System.Xml.Schema;
using System;
using System.ComponentModel;
using Project.Utility;

namespace Project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, INotifyPropertyChanged
    {


        // HCI
        public ResourceDictionary ThemeDictionary
        {
            get { return Resources.MergedDictionaries[0]; }
        }

        public ResourceDictionary LanguageDictionary
        {
            get { return Resources.MergedDictionaries[1]; }
        }

        public void ChangeLanguage(Uri uri)
        {
            LanguageDictionary.MergedDictionaries.Clear();
            LanguageDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
        }

        public void ChangeTheme(Uri uri)
        {
            ThemeDictionary.MergedDictionaries.Clear();
            ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
        }

        public void AddTheme(Uri uri)
        {
            ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
        }


        public List<DoctorDTO> doctors { get; set; }
        public List<PatientDTO> patients { get; set; }
        public List<DirectorDTO> directors { get; set; }
        public List<SecretaryDTO> secretaries { get; set; }
        public List<EmployeeDTO> employees { get; set; }
        public List<RoomDTO> rooms { get; set; }
        private DoctorDTO selectedDoctor;
        public DoctorDTO SelectedDoctor
        {
            get
            {
                return selectedDoctor;
            }
            set
            {
                if (value != selectedDoctor)
                {
                    selectedDoctor = value;
                    OnPropertyChanged("SelectedDoctor");
                }
            }
        }
        private PatientDTO selectedPatient;
        public PatientDTO SelectedPatient
        {
            get
            {
                return selectedPatient;
            }
            set
            {
                if (value != selectedPatient)
                {
                    selectedPatient = value;
                    OnPropertyChanged("SelectedPatient");
                }
            }
        }
        private List<MedicalAppointmentDTO> medicalAppointments;
        public List<MedicalAppointmentDTO> MedicalAppointments
        {
            get
            {
                return medicalAppointments;
            }
            set
            {
                if (value != medicalAppointments)
                {
                    medicalAppointments = value;
                    OnPropertyChanged("MedicalAppointments");
                }
            }
        }
        private MedicalAppointmentDTO selectedAppointment;
        public MedicalAppointmentDTO SelectedAppointment
        {
            get { return selectedAppointment; }
            set
            {
                if (value != selectedAppointment)
                {
                    selectedAppointment = value;
                    OnPropertyChanged("SelectedAppointment");
                }
            }
        }
        public SecretaryDTO currentSecretary { get; set; }
        public List<string> medicalRoles { get; set; }
        public List<string> roomTypes { get; set; }
        public List<string> medicalAppointmentTypes { get; set; }

        //
        private static string PATIENT_FILEPATH = ConfigurationManager.AppSettings["PatientPath"].ToString();
        private static string QUESTION_FILEPATH = ConfigurationManager.AppSettings["QuestionPath"].ToString();
        private static string DELIMITER = ConfigurationManager.AppSettings["DelimiterValue"].ToString();
        private static string DATETIME_FORMAT = ConfigurationManager.AppSettings["DateTimeFormat"].ToString();

        private static string REPORT_ROOM_PATH = ConfigurationManager.AppSettings["ReportRoomPath"].ToString();
        private static string REPORT_APPOINTMENT_PATH = ConfigurationManager.AppSettings["ReportAppointmentPath"].ToString();

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public App()
        {

            // HCI

            medicalRoles = new List<string> { "Svi", "Opšte Prakse", "Hirurg", "Dermatolog", "Očni lekar" };
            roomTypes = new List<string> { "Bolnička Soba", "Operaciona Sala", "Soba za preglede" };
            medicalAppointmentTypes = new List<string> { "Pregled", "Operacija", "Ležanje" };

            doctors = new List<DoctorDTO>
            {
                new DoctorDTO(
                1, new AddressDTO(1, "7A", "Bulevar despota Stefana", "Novi Sad", "Srbija", "21000"),
                "Filip", "Zdelar", "123241129993", "+381604223222", "male", new DateTime(), 67000.00,
                new TimeInterval(new DateTime(), new DateTime()), new TimeInterval(new DateTime(), new DateTime()),
                "a22@gmail.com", "pass123", medicalRoles[1]),
                new DoctorDTO(
                2, new AddressDTO(1, "7A", "Bulevar despota Stefana", "Novi Sad", "Srbija", "21000"),
                "Nikola", "Selić", "123241129993", "+381604223222", "male", new DateTime(), 67000.00,
                new TimeInterval(new DateTime(), new DateTime()), new TimeInterval(new DateTime(), new DateTime()),
                "asdf@gmail.com", "pass123",  medicalRoles[2]),
                new DoctorDTO(
                3, new AddressDTO(1, "7A", "Bulevar despota Stefana", "Novi Sad", "Srbija", "21000"),
                "Ivana", "Blagojević", "123241129993", "+381604223222", "female", new DateTime(), 67000.00,
                new TimeInterval(new DateTime(), new DateTime()), new TimeInterval(new DateTime(), new DateTime()),
                "filip.zdelar@gmail.com", "pass123", medicalRoles[3])
            };
            secretaries = new List<SecretaryDTO>
            {
                new SecretaryDTO(
                1, new AddressDTO(1, "7A", "Bulevar despota Stefana", "Novi Sad", "Srbija", "21000"),
                "Filip", "Zdelar", "123241129993", "+381604223222", "male", new DateTime(), 67000.00,
                new TimeInterval(new DateTime(), new DateTime()), new TimeInterval(new DateTime(), new DateTime()),
                "selic.work@gmail.com", "pass"),
            };
            directors = new List<DirectorDTO>
            {
                new DirectorDTO(
                1, new AddressDTO(1, "7A", "Bulevar despota Stefana", "Novi Sad", "Srbija", "21000"),
                "Filip", "Zdelar", "123241129993", "+381604223222", "male", new DateTime(), 67000.00,
                new TimeInterval(new DateTime(), new DateTime()), new TimeInterval(new DateTime(), new DateTime()),
                "dusan998@gmail.com", "pass"),
            };

            
            patients = new List<PatientDTO>
            {
                new PatientDTO(
                4, new AddressDTO(1, "7A", "Bulevar despota Stefana", "Novi Sad", "Srbija", "21000"),
                "Darko", "Majstorović", "123241129993", "+381604223222", "male", new DateTime().AddYears(2000).AddDays(20),
                "08763646483684", "Diplomirani Istoričar", "0-", 185, 92, "darkomajstorovic@gmail.com", "pass"),
                new PatientDTO(
                5, new AddressDTO(1, "7A", "Bulevar despota Stefana", "Novi Sad", "Srbija", "21000"),
                "Marija", "Sazdanović", "123241129993", "+381604223222", "female", new DateTime().AddYears(1994).AddDays(280),
                "08763646483684", "Diplomirani Istoričar", "0-", 168, 62, "marijasazdanovic@gmail.com", "pass"),
                new PatientDTO(
                6, new AddressDTO(1, "7A", "Bulevar despota Stefana", "Novi Sad", "Srbija", "21000"),
                "Zeljko", "Majstorović", "123241129993", "+381604223222", "male", new DateTime().AddYears(1997).AddDays(200),
                "08763646483684", "Diplomirani Istoričar", "0-", 185, 92, "bicatrofrtaljka@gmail.com", "pass"),
                new PatientDTO(
                7, new AddressDTO(1, "7A", "Bulevar despota Stefana", "Novi Sad", "Srbija", "21000"),
                "Uros", "Milovanovic", "123241129993", "+381604223222", "male", new DateTime().AddYears(2000).AddDays(20),
                "08763646483684", "Diplomirani Kompjuteras", "0-", 185, 92, "urkem98@gmail.com", "pass"),
            };
            rooms = new List<RoomDTO>() {
                new RoomDTO(1, RoomType.hospitalRoom, "One", "Check"),
                new RoomDTO(2, RoomType.hospitalRoom, "One", "Check"),
                new RoomDTO(3, RoomType.hospitalRoom, "One", "Check"),
                new RoomDTO(5, RoomType.hospitalRoom, "One", "Check")
            };
            medicalAppointments = new List<MedicalAppointmentDTO>{
                new MedicalAppointmentDTO(
                    0, new DateTime(),  new DateTime(),
                    rooms[0], MedicalAppointmentType.examination ,
                    patients[0], new List<DoctorDTO>{ doctors[0], doctors[1] }),
                new MedicalAppointmentDTO(
                    1, new DateTime(),  new DateTime(),
                    rooms[0], MedicalAppointmentType.examination ,
                    patients[0], new List<DoctorDTO>{ doctors[0], doctors[1] })
            };
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

            // Generators
            GenerateSecretaryReport = new GenerateSecretaryReport(REPORT_APPOINTMENT_PATH);
            GeneratePatientReport = new GeneratePatientReport(REPORT_APPOINTMENT_PATH);

            // Controllers
            PatientController = new PatientController(patientService, patientConverter);
            QuestionController = new QuestionController(questionService, questionConverter, patientConverter);
            AuthenticationController = new AuthenticationController();
            ReportController = new ReportController();
        }



        public IPDFReport<TimeInterval> GenerateSecretaryReport { get; private set; }
        public IPDFReport<TimeInterval> GeneratePatientReport { get; private set; }

        public AuthenticationController AuthenticationController { get; private set; }
        public IController<PatientDTO, long> PatientController { get; private set; }
        public ReportController ReportController { get; private set; }
        public IController<QuestionDTO, long> QuestionController { get; private set; }

    }
}
