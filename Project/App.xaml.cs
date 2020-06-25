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
using Project.Services.Generators;
using Project.Repositories.ManyToMany.Repositories;
using Project.Repositories.ManyToMany.Model;
using Project.Repositories.ManyToMany.Converter;
using Syncfusion.Windows.Shared;
using Project.Repositories.CSV;

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
        private static string ORDER_FILEPATH = ConfigurationManager.AppSettings["OrderPath"].ToString();
        private static string ORDER_DETAILS_FILEPATH = ConfigurationManager.AppSettings["OrderDetailsPath"].ToString();
        private static string MEDICAL_APPOINTMENT_FILEPATH = ConfigurationManager.AppSettings["MedicalAppointmentPath"].ToString();
        private static string ROOM_PATH = ConfigurationManager.AppSettings["RoomPath"].ToString();
        private static string RENOVATION_PATH = ConfigurationManager.AppSettings["RenovationPath"].ToString();
        private static string FEEDBACK_FILEPATH = ConfigurationManager.AppSettings["FeedbackPath"].ToString();
        private static string REVIEW_PATH = ConfigurationManager.AppSettings["ReviewPath"].ToString();
        private static string ANAMNESIS_PATH = ConfigurationManager.AppSettings["AnamnesisPath"].ToString();
        private static string SECRETARY_FILEPATH = ConfigurationManager.AppSettings["SecretaryPath"].ToString();
        private static string INVENTORY_PATH = ConfigurationManager.AppSettings["InventoryPath"].ToString();
        private static string INVENTORY_EQUIPMENT_PATH = ConfigurationManager.AppSettings["InventoryEquipmentPath"].ToString();
        private static string DOCTOR_FILEPATH = ConfigurationManager.AppSettings["DoctorPath"].ToString();

        // Many to many
        private static string MEDICAL_APPOINTMENT_TO_DOCTOR_FILEPATH = ConfigurationManager.AppSettings["MedicalAppointmentToDoctorPath"].ToString();
        
        // Report paths
        private static string REPORT_ROOM_PATH = ConfigurationManager.AppSettings["ReportRoomPath"].ToString();
        private static string REPORT_APPOINTMENT_PATH = ConfigurationManager.AppSettings["ReportAppointmentPath"].ToString();
        private static string REPORT_PRESCRIPTION_PATH = ConfigurationManager.AppSettings["ReportPrescriptionPath"].ToString();

        // Constants
        private static string DELIMITER = ConfigurationManager.AppSettings["DelimiterValue"].ToString();
        private static string DATETIME_FORMAT = ConfigurationManager.AppSettings["DateTimeFormat"].ToString();
        private static string DATETIME_DETAIL_FORMAT = ConfigurationManager.AppSettings["DateTimeDetailFormat"].ToString();



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
                "a@g.c", "p", medicalRoles[1])
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
                7, new AddressDTO(1, "7A", "Bulevar despota Stefana", "Novi Sad", "Srbija", "21000"),
                "Uros", "Milovanovic", "123241129993", "+381604223222", "male", new DateTime().AddYears(2000).AddDays(20),
                "08763646483684", "Diplomirani Kompjuteras", "0-", 185, 92, "urkem98@gmail.com", "pass"),
            };

            questions = new List<QuestionDTO>
            {
                new QuestionDTO(0,"Da li je moguće zakazivanje preko interneta", "Svakako.", patients[0], secretaries[0], DateTime.Now.AddDays(-5))
            };

                //new RoomDTO(111, RoomType.hospitalRoom, "1. Sprat", "Check"),


            // Converters
            var addressConverter = new AddressConverter();
            var patientConverter = new PatientConverter(addressConverter);
            var medicineConverter = new MedicineConverter();
            var questionConverter = new QuestionConverter(patientConverter);
            var prescriptionConverter = new PrescriptionConverter(patientConverter, medicineConverter);
            var medicalConsumableConverter = new MedicalConsumableConverter();
            var roomConverter = new RoomConverter();
            var equipmentConverter = new EquipmentConverter(roomConverter);
            var guestConverter = new GuestConverter(addressConverter);
            var hospitalConverter = new HospitalConverter();
            var doctorConverter = new DoctorConverter(addressConverter);
            var medicalAppoitmentConverter = new MedicalAppointmentConverter(roomConverter, guestConverter, doctorConverter);
            var renovationConverter = new RenovationConverter(roomConverter);
            var feedbackConverter = new FeedbackConverter();
            var reviewConverter = new ReviewConverter(doctorConverter);
            var anamnesisConvertor = new AnamnesisConvertor();
            var secretaryConverter = new SecretaryConverter(questionConverter, addressConverter);
            var inventoryManagementConverter = new InventoryManagementConverter(equipmentConverter, roomConverter);
            var orderConverter = new OrderConverter(medicalConsumableConverter,medicineConverter,equipmentConverter);

        //     ICSVStream<Patient> stream,
        //     IAddressRepository addressRepository,
        //     ISequencer<long> sequencer
        //     ) : base(ENTITY_NAME, stream, sequencer)
        // {
        //     _addressRepository = addressRepository;
        // }
            // Repositories
            // Many to Many
            var medicalAppointmentToDoctorRepository = new MedicalAppointmentToDoctorRepository(
                new CSVStream<MedicalAppointmentToDoctor>(
                    MEDICAL_APPOINTMENT_TO_DOCTOR_FILEPATH, 
                    new MedicalAppointmentToDoctorCSVConverter(DELIMITER)),
                new LongSequencer()
            );
            var inventoryManagementToEquipmentRepository = new InventoryManagementToEquipmentRepository(
                new CSVStream<InventoryManagementToEquipment>(
                    INVENTORY_EQUIPMENT_PATH,
                    new InventoryManagementToEquipmentCSVConverter(DELIMITER)),
                new LongSequencer()
            );



            // var patientCSVRepository = new UserCSVRepository<Patient, User, long>(
            //     "Patient", patientStrea

            // )
            var addressRepository = new AddressRepository(new CSVStream<Address>(ADDRESS_FILEPATH, new AddressCSVConverter(DELIMITER)), new LongSequencer());
            var patientRepository = new PatientRepository(
                new CSVStream<Patient>(PATIENT_FILEPATH, new PatientCSVConverter(DELIMITER, DATETIME_FORMAT)),
                new CSVStream<Patient>(PATIENT_FILEPATH, new PatientCSVConverter(DELIMITER, DATETIME_FORMAT)),
                new CSVStream<Doctor>(DOCTOR_FILEPATH, new DoctorCSVConverter(DELIMITER, DATETIME_FORMAT)),
                new CSVStream<Secretary>(SECRETARY_FILEPATH, new SecretaryCSVConverter(DELIMITER, DATETIME_FORMAT)),
                addressRepository , new LongSequencer());
            var doctorRepository = new DoctorRepository(
                new CSVStream<Doctor>(DOCTOR_FILEPATH, new DoctorCSVConverter(DELIMITER, DATETIME_FORMAT)),
                new CSVStream<Patient>(PATIENT_FILEPATH, new PatientCSVConverter(DELIMITER, DATETIME_FORMAT)),
                new CSVStream<Doctor>(DOCTOR_FILEPATH, new DoctorCSVConverter(DELIMITER, DATETIME_FORMAT)),
                new CSVStream<Secretary>(SECRETARY_FILEPATH, new SecretaryCSVConverter(DELIMITER, DATETIME_FORMAT)),
                addressRepository,
                new LongSequencer());
            var secretaryRepository = new SecretaryRepository(
                new CSVStream<Secretary>(SECRETARY_FILEPATH, new SecretaryCSVConverter(DELIMITER,DATETIME_FORMAT)), 
                new CSVStream<Patient>(PATIENT_FILEPATH, new PatientCSVConverter(DELIMITER, DATETIME_FORMAT)),
                new CSVStream<Doctor>(DOCTOR_FILEPATH, new DoctorCSVConverter(DELIMITER, DATETIME_FORMAT)),
                new CSVStream<Secretary>(SECRETARY_FILEPATH, new SecretaryCSVConverter(DELIMITER, DATETIME_FORMAT)),
                addressRepository,
                new LongSequencer());
            var inventoryManagementRepository = new InventoryManagementRepository(new CSVStream<InventoryManagement>(INVENTORY_PATH, new InventoryManagementCSVConverter(DELIMITER,DATETIME_FORMAT)), inventoryManagementToEquipmentRepository, new LongSequencer());
            var orderDetailsRepository = new OrderDetailsRepository( new CSVStream<OrderDetails>( ORDER_DETAILS_FILEPATH ,new OrderDetailsCSVConverter(DELIMITER)), new LongSequencer());
            var questionRepository = new QuestionRepository(new CSVStream<Question>(QUESTION_FILEPATH, new QuestionCSVConverter(DELIMITER, DATETIME_FORMAT)), new LongSequencer());
            var medicineRepository = new MedicineRepository(new CSVStream<Medicine>(MEDICINE_FILEPATH, new MedicineCSVConverter(DELIMITER)), new LongSequencer());
            var prescriptionRepository = new PrescriptionRepository(new CSVStream<Prescription>( PRESCRIPTION_FILEPATH, new PrescriptionCSVConverter(DELIMITER, DATETIME_FORMAT)), medicineRepository, patientRepository, new LongSequencer());
            var medicalConsumableRepository = new MedicalConsumableRepository(new CSVStream<MedicalConsumables>(MEDICAL_CONSUMABLE_FILEPATH, new MedicalConsumableCSVConverter(DELIMITER)), new LongSequencer());
            var equipmentRepository = new EquipmentRepository(new CSVStream<Equipment>(EQUIPMENT_FILEPATH, new EquipmentCSVConverter(DELIMITER)), new LongSequencer());
            var medicalAppoitmentRepository = new MedicalAppointmentRepository(
                new CSVStream<MedicalAppointment>(MEDICAL_APPOINTMENT_FILEPATH, 
                new MedicalAppointmentCSVConverter(DELIMITER, DATETIME_DETAIL_FORMAT)), 
                medicalAppointmentToDoctorRepository,
                patientRepository,
                doctorRepository,
                new LongSequencer());
            var roomRepository = new RoomRepository(new CSVStream<Room>(ROOM_PATH, new RoomCSVConverter(DELIMITER)),new LongSequencer(),equipmentRepository);

            var orderRepository = new OrderRepository( new CSVStream<Order>(ORDER_FILEPATH, new OrderCSVConverter(DELIMITER, DATETIME_FORMAT)), medicineRepository, equipmentRepository, medicalConsumableRepository, orderDetailsRepository, new LongSequencer());

            var renovationRepository = new RenovationRepository(new CSVStream<Renovation>(RENOVATION_PATH, new RenovationCSVConverter(DELIMITER, DATETIME_FORMAT)), new LongSequencer());
            var feedbackRepository = new FeedbackRepository(new CSVStream<Feedback>(FEEDBACK_FILEPATH, new FeedbackCSVConverter(DELIMITER)), new LongSequencer());
            var reviewRepository=new ReviewRepository(new CSVStream<Review>(REVIEW_PATH, new ReviewCSVConverter(DELIMITER)), new LongSequencer());
            var anamnesisRepository = new AnamnesisRepository(new CSVStream<Anamnesis>(ANAMNESIS_PATH, new AnamnesisCSVConverter(DELIMITER)), new LongSequencer());

            // Services
            var patientService = new PatientService(patientRepository);
            var questionService = new QuestionService(questionRepository);
            var addressService = new AddressService(addressRepository);
            var medicineService = new MedicineService(medicineRepository);
            var medicalConsumableService = new MedicalConsumableService(medicalConsumableRepository);
            var prescriptionService = new PrescriptionService(prescriptionRepository, medicineService, patientService);
            var reportService = new ReportService();
            var equipmentService = new EquipmentService(equipmentRepository);
            var medicalAppoitmentService = new MedicalAppointmentService(medicalAppoitmentRepository);
            var roomService = new RoomService(roomRepository);
            var renovationService = new RenovationService(renovationRepository);
            var feedbackService = new FeedbackService(feedbackRepository);
            var reviewService = new ReviewService(reviewRepository);
            var employeeService = new EmployeeService(secretaryRepository, doctorRepository);
            var authenticationService = new AuthenticationService(employeeService, patientService);
            var secretaryService = new SecretaryService(secretaryRepository);
            var inventoryManagementService = new InventoryManagementService(inventoryManagementRepository);
            var orderService = new OrderService(orderRepository);
            var doctorService = new DoctorService(doctorRepository);
            var anamnesisService = new AnamnesisService(anamnesisRepository);

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
            MedicalAppointmentController = new MedicalAppointmentController(medicalAppoitmentService, medicalAppoitmentConverter);
            RoomController = new RoomController(roomService, roomConverter);
            RenovationController = new RenovationController(renovationService, renovationConverter);
            FeedbackController = new FeedbackController(feedbackService, feedbackConverter);
            ReviewController = new ReviewController(reviewService, reviewConverter);
            SecretaryController = new SecretaryController(secretaryService, secretaryConverter);
            InventoryManagementController = new InventoryManagementController(inventoryManagementService, inventoryManagementConverter);
            OrderController = new OrderController(orderService, orderConverter);
            DoctorController = new DoctorController(doctorService, doctorConverter);
            AnamnesisController = new AnamnesisController(anamnesisService, anamnesisConvertor);

            // Generators
            SecretaryAppointmentReportGenerator = new SecretaryAppointmentReportGenerator(REPORT_APPOINTMENT_PATH);
            PatientAppointmentReportGenerator = new PatientAppointmentReportGenerator(REPORT_APPOINTMENT_PATH);
            PrescriptionReportGenerator = new PrescriptionReportGenerator(REPORT_PRESCRIPTION_PATH); 
        }



        // Generators
        public IReportGenerator<TimeInterval> SecretaryAppointmentReportGenerator { get; private set; }
        public IReportGenerator<TimeInterval> PatientAppointmentReportGenerator { get; private set; }
        public IReportGenerator<TimeInterval> PrescriptionReportGenerator { get; private set; }

        // Controllers
        public AuthenticationController AuthenticationController { get; private set; }
        public IController<SecretaryDTO, long> SecretaryController { get; private set; }
        public ReportController ReportController { get; private set; }
        public IController<PatientDTO, long> PatientController { get; private set; }
        public IController<AddressDTO, long> AddressController { get; private set; }
        public IController<MedicineDTO, long> MedicineController { get; private set; }
        public IController<MedicalConsumableDTO, long> MedicalConsumableController { get; private set; }

        public IController<EquipmentDTO, long> EquipmentController { get; private set; }
        public IController<RoomDTO, long> RoomController { get; private set; }
        public IController<RenovationDTO, long> RenovationController { get; private set; }
        public IController<InventoryManagementDTO, long> InventoryManagementController { get; private set; }
        public IController<OrderDTO, long> OrderController { get; private set; }

        public IController<DoctorDTO, long> DoctorController { get; private set; }
        public MedicalAppointmentController MedicalAppointmentController { get; private set; }

        public IController<QuestionDTO, long> QuestionController { get; private set; }
        public IController<FeedbackDTO, long> FeedbackController { get; private set; }

        public IController<ReviewDTO, long> ReviewController { get; private set; }
        public IController<PrescriptionDTO, long> PrescriptionController { get; private set; }
        public IController<AnamnesisDTO, long> AnamnesisController { get; set; }

    }
}
