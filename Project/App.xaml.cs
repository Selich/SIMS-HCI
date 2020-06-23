﻿using System.Configuration;
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
using Project.Services.Generators;

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
        public List<QuestionDTO> questions { get; set; }
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
        public DateTime SelectedDate { get; set; }

        // Paths
        private static string PATIENT_FILEPATH = ConfigurationManager.AppSettings["PatientPath"].ToString();
        private static string ADDRESS_FILEPATH = ConfigurationManager.AppSettings["AddressPath"].ToString();
        private static string QUESTION_FILEPATH = ConfigurationManager.AppSettings["QuestionPath"].ToString();
        private static string MEDICINE_FILEPATH = ConfigurationManager.AppSettings["MedicinePath"].ToString();
        private static string PRESCRIPTION_FILEPATH = ConfigurationManager.AppSettings["PrescriptionPath"].ToString();
        private static string MEDICAL_CONSUMABLE_FILEPATH= ConfigurationManager.AppSettings["MedicalConsumablesPath"].ToString();
        private static string EQUIPMENT_FILEPATH = ConfigurationManager.AppSettings["EquipmentPath"].ToString();
        
        // Report paths
        private static string REPORT_ROOM_PATH = ConfigurationManager.AppSettings["ReportRoomPath"].ToString();
        private static string REPORT_APPOINTMENT_PATH = ConfigurationManager.AppSettings["ReportAppointmentPath"].ToString();
        private static string REPORT_RECIPE_PATH = ConfigurationManager.AppSettings["ReportAppointmentPath"].ToString();

        // Constants
        private static string DELIMITER = ConfigurationManager.AppSettings["DelimiterValue"].ToString();
        private static string DATETIME_FORMAT = ConfigurationManager.AppSettings["DateTimeFormat"].ToString();



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
            SelectedDate = DateTime.Now;


            doctors = new List<DoctorDTO>
            {
                new DoctorDTO(
                1, new AddressDTO(1, "7A", "Bulevar despota Stefana", "Novi Sad", "Srbija", "21000"),
                "Branislav", "Draganic", "123241129993", "+381604223222", "male", new DateTime(), 67000.00,
                new TimeInterval(new DateTime(), new DateTime()), new TimeInterval(new DateTime(), new DateTime()),
                "a@g.c", "p", medicalRoles[1]),
                new DoctorDTO(
                2, new AddressDTO(1, "7A", "Bulevar despota Stefana", "Novi Sad", "Srbija", "21000"),
                "Nikola", "Selic", "123241129993", "+381604223222", "male", new DateTime(), 67000.00,
                new TimeInterval(new DateTime(), new DateTime()), new TimeInterval(new DateTime(), new DateTime()),
                "asdf@gmail.com", "pass123",  medicalRoles[2]),
                new DoctorDTO(
                3, new AddressDTO(1, "7A", "Bulevar despota Stefana", "Novi Sad", "Srbija", "21000"),
                "Ivana", "Blagojevic", "123241129993", "+381604223222", "female", new DateTime(), 67000.00,
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
                "Darko", "Majstorovic", "123241129993", "+381604223222", "male", new DateTime().AddYears(2000).AddDays(20),
                "08763646483684", "Diplomirani Istoričar", "0-", 185, 92, "darkomajstorovic@gmail.com", "pass"),
                new PatientDTO(
                5, new AddressDTO(1, "7A", "Bulevar despota Stefana", "Novi Sad", "Srbija", "21000"),
                "Marija", "Sazdanovic", "123241129993", "+381604223222", "female", new DateTime().AddYears(1994).AddDays(280),
                "08763646483684", "Diplomirani Istoričar", "0-", 168, 62, "marijasazdanovic@gmail.com", "pass"),
                new PatientDTO(
                6, new AddressDTO(1, "7A", "Bulevar despota Stefana", "Novi Sad", "Srbija", "21000"),
                "Zeljko", "Majstorovic", "123241129993", "+381604223222", "male", new DateTime().AddYears(1997).AddDays(200),
                "08763646483684", "Diplomirani Istoričar", "0-", 185, 92, "bicatrofrtaljka@gmail.com", "pass"),
                new PatientDTO(
                7, new AddressDTO(1, "7A", "Bulevar despota Stefana", "Novi Sad", "Srbija", "21000"),
                "Uros", "Milovanovic", "123241129993", "+381604223222", "male", new DateTime().AddYears(2000).AddDays(20),
                "08763646483684", "Diplomirani Kompjuteras", "0-", 185, 92, "urkem98@gmail.com", "pass"),
                new PatientDTO(
                8, new AddressDTO(1, "7A", "Bulevar despota Stefana", "Novi Sad", "Srbija", "21000"),
                "Emir", "Dep", "123241129993", "+381604223222", "male", new DateTime().AddYears(2000).AddDays(20),
                "08763646483684", "Diplomirani Kompjuteras", "0-", 185, 92, "dep@gmail.com", "pass"),
                new PatientDTO(
                9, new AddressDTO(1, "7A", "Bulevar despota Stefana", "Novi Sad", "Srbija", "21000"),
                "Covek", "Jelovac", "123241129993", "+381604223222", "male", new DateTime().AddYears(2000).AddDays(20),
                "08763646483684", "Diplomirani Kompjuteras", "0-", 185, 92, "urm98@gmail.com", "pass"),
                new PatientDTO(
                10, new AddressDTO(1, "7A", "Bulevar despota Stefana", "Novi Sad", "Srbija", "21000"),
                "Boli", "Glava", "123241129993", "+381604223222", "male", new DateTime().AddYears(2000).AddDays(20),
                "08763646483684", "Diplomirani Kompjuteras", "0-", 185, 92, "boli@gmail.com", "pass"),
                new PatientDTO(
                10, new AddressDTO(1, "7A", "Bulevar despota Stefana", "Novi Sad", "Srbija", "21000"),
                "Hasan", "Seckati", "123241129993", "+381604223222", "male", new DateTime().AddYears(2000).AddDays(20),
                "08763646483684", "Diplomirani Kompjuteras", "0-", 185, 92, "bsi@gmail.com", "pass"),
            };
            questions = new List<QuestionDTO>
            {
                new QuestionDTO(0,"Da li je moguće zakazivanje preko interneta", "Svakako.", patients[0], secretaries[0], DateTime.Now.AddDays(-5)),
                new QuestionDTO(1,"Da li je moguć pregled kod Slavke", "", patients[1], secretaries[0], DateTime.Now.AddDays(-8)),
                new QuestionDTO(2,"Da li je moguć pregled kod Birovoja", "", patients[2], secretaries[0], DateTime.Now.AddDays(-2)),
                new QuestionDTO(3,"Da li je moguć pregled kod Slavke", "", patients[3], secretaries[0], DateTime.Now.AddDays(-1)),
                new QuestionDTO(4,"Da li je moguć svakodnevni pregled", "", patients[1], secretaries[0], DateTime.Now.AddDays(-8))
            };
            rooms = new List<RoomDTO>() {
                new RoomDTO(111, RoomType.hospitalRoom, "1. Sprat", "Check"),
                new RoomDTO(202, RoomType.hospitalRoom, "2. Sprat", "Check"),
                new RoomDTO(377, RoomType.hospitalRoom, "Prizemlje", "Check"),
                new RoomDTO(404, RoomType.hospitalRoom, "Prizemlje", "Check")
            };
            medicalAppointments = new List<MedicalAppointmentDTO>{
                new MedicalAppointmentDTO(
                    0, DateTime.Now.AddHours(-1),  DateTime.Now,
                    rooms[0], MedicalAppointmentType.examination ,
                    patients[0], new List<DoctorDTO>{ doctors[0], doctors[1] }),
                new MedicalAppointmentDTO(
                    1, DateTime.Now.AddHours(-2),  DateTime.Now.AddHours(-1),
                    rooms[0], MedicalAppointmentType.examination ,
                    patients[1], new List<DoctorDTO>{ doctors[1], doctors[1] }),
                new MedicalAppointmentDTO(
                    2, DateTime.Now.AddHours(-3),  DateTime.Now.AddHours(-2),
                    rooms[0], MedicalAppointmentType.examination ,
                    patients[2], new List<DoctorDTO>{ doctors[2], doctors[1] }),
                new MedicalAppointmentDTO(
                    2, DateTime.Now.AddHours(-6),  DateTime.Now.AddHours(-3),
                    rooms[0], MedicalAppointmentType.operation ,
                    patients[3], new List<DoctorDTO>{ doctors[2], doctors[1] }),
                new MedicalAppointmentDTO(
                    3, DateTime.Now.AddHours(-16),  DateTime.Now.AddHours(-13),
                    rooms[0], MedicalAppointmentType.examination ,
                    patients[4], new List<DoctorDTO>{ doctors[1], doctors[1] }),
                new MedicalAppointmentDTO(
                    4, DateTime.Now.AddHours(-6),  DateTime.Now.AddHours(-3),
                    rooms[0], MedicalAppointmentType.examination ,
                    patients[5], new List<DoctorDTO>{ doctors[0], doctors[1] }),
                new MedicalAppointmentDTO(
                    5, DateTime.Now.AddHours(-26),  DateTime.Now.AddHours(-23),
                    rooms[0], MedicalAppointmentType.examination ,
                    patients[6], new List<DoctorDTO>{ doctors[2], doctors[1] })
            };
            // Converters
            var patientConverter = new PatientConverter();
            var medicineConverter = new MedicineConverter();
            var addressConverter = new AddressConverter();
            var questionConverter = new QuestionConverter(patientConverter);
            var prescriptionConverter = new PrescriptionConverter(patientConverter, medicineConverter);
            var medicalConsumableConverter = new MedicalConsumableConverter();
            var roomConverter = new RoomConverter();
            var equipmentConverter = new EquipmentConverter(roomConverter);

            // Repositories
            var patientRepository = new PatientRepository(new CSVStream<Patient>(PATIENT_FILEPATH, new PatientCSVConverter(DELIMITER, DATETIME_FORMAT)), new LongSequencer());
            var questionRepository = new QuestionRepository(new CSVStream<Question>(QUESTION_FILEPATH, new QuestionCSVConverter(DELIMITER, DATETIME_FORMAT)), new LongSequencer());
            var medicineRepository = new MedicineRepository(new CSVStream<Medicine>(MEDICINE_FILEPATH, new MedicineCSVConverter(DELIMITER)), new LongSequencer());
            var prescriptionRepository = new PrescriptionRepository(new CSVStream<Prescription>(PRESCRIPTION_FILEPATH, new PrescriptionCSVConverter(DELIMITER, DATETIME_FORMAT)), new LongSequencer());
            var medicalConsumableRepository = new MedicalConsumableRepository(new CSVStream<MedicalConsumables>(MEDICAL_CONSUMABLE_FILEPATH, new MedicalConsumableCSVConverter(DELIMITER)), new LongSequencer());
            var equipmentRepository = new EquipmentRepository(new CSVStream<Equipment>(EQUIPMENT_FILEPATH, new EquipmentCSVConverter(DELIMITER)), new LongSequencer());

            var addressRepository = new AddressRepository(new CSVStream<Address>(ADDRESS_FILEPATH, new AddressCSVConverter(DELIMITER)), new LongSequencer());
            // Services
            var patientService = new PatientService(patientRepository);
            var questionService = new QuestionService(questionRepository);
            var addressService = new AddressService(addressRepository);
            var medicineService = new MedicineService(medicineRepository);
            var medicalConsumableService = new MedicalConsumableService(medicalConsumableRepository);
            var prescriptionService = new PrescriptionService(prescriptionRepository, medicineService, patientService);
            var reportService = new ReportService();
            var equipmentService = new EquipmentService(equipmentRepository);

            // Controllers
            PatientController = new PatientController(patientService, patientConverter);
            AddressController = new AddressController(addressService, addressConverter);
            MedicineController = new MedicineController(medicineService, medicineConverter);
            QuestionController = new QuestionController(questionService, questionConverter, patientConverter);
            MedicalConsumableController = new MedicalConsumableController(medicalConsumableService, medicalConsumableConverter);
            AuthenticationController = new AuthenticationController();
            ReportController = new ReportController();
            PrescriptionController = new PrescriptionController(prescriptionService, prescriptionConverter);
            EquipmentController = new EquipmentController(equipmentService, equipmentConverter);
            // Generators
            SecretaryAppointmentReportGenerator = new SecretaryAppointmentReportGenerator(REPORT_APPOINTMENT_PATH);
            PatientAppointmentReportGenerator = new PatientAppointmentReportGenerator(REPORT_APPOINTMENT_PATH);
            PrescriptionReportGenerator = new PrescriptionReportGenerator(REPORT_RECIPE_PATH);
        }



        // Generators
        public IReportGenerator<TimeInterval> SecretaryAppointmentReportGenerator { get; private set; }
        public IReportGenerator<TimeInterval> PatientAppointmentReportGenerator { get; private set; }
        public IReportGenerator<TimeInterval> PrescriptionReportGenerator { get; private set; }

        // Controllers
        public AuthenticationController AuthenticationController { get; private set; }
        public ReportController ReportController { get; private set; }
        public IController<PatientDTO, long> PatientController { get; private set; }
        public IController<AddressDTO, long> AddressController { get; private set; }
        public IController<MedicineDTO, long> MedicineController { get; private set; }
        public IController<MedicalConsumableDTO, long> MedicalConsumableController { get; private set; }

        public IController<EquipmentDTO, long> EquipmentController { get; private set; }

        public IController<QuestionDTO, long> QuestionController { get; private set; }
        public IController<PrescriptionDTO, long> PrescriptionController { get; private set; }

    }
}
