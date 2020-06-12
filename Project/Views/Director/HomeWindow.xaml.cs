using Controller;
using iTextSharp.text.pdf;
using Project.Controllers;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Project.Views.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Project.Views.Director
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    /// 

    /*
     private string test1; --Binding je na Test1
     public string Test1
        {
            get
            {
                return test1;
            }
            set
            {
                if (value != test1)
                {
                    test1 = value;
                    OnPropertyChanged("Test1");
                }
            }
        }
     */
    public partial class HomeWindow : Window, INotifyPropertyChanged
    {
        private ReportController _reportController;
        public AddressDTO DirectorAddress { get; set; }
        public DirectorDTO Director { get; set; }


        public ObservableCollection<PropositionDTO> Propositions {get; set;}

        public ObservableCollection<EmployeeDTO> Employees { get; set; }

        public ObservableCollection<EquipmentDTO> Equipment { get; set; }

        public ObservableCollection<MedicalConsumableDTO> MedicalConsumables { get; set; }

        public ObservableCollection<MedicineDTO> Medicine { get; set; }

        public ObservableCollection<RoomDTO> RoomList { get; set; }

        public RoomDTO Magacin { get; set; }


        // public EmployeeDTO SelectedEmployee { get; set; }
        private RoomDTO selectedRoom;
        public RoomDTO SelectedRoom
        {
            get
            {
                return selectedRoom;
            }
            set
            {
                if (value != selectedRoom)
                {
                    selectedRoom = value;
                    OnPropertyChanged("SelectedRoom");
                }
            }
        }

        private ObservableCollection<AppointmentDTO> selectedRoomAppointments;

        public ObservableCollection<AppointmentDTO> SelectedRoomAppointments
            {
                get
                {
                    return selectedRoomAppointments;
                }
                set
                {
                    if (value != selectedRoomAppointments)
                    {
                        selectedRoomAppointments = value;
                        OnPropertyChanged("SelectedRoomAppointments");
                    }
                }
            }
        

        public HomeWindow()
        {
           
            InitializeComponent();
            this.DataContext = this;
            var app = Application.Current as App;

            _reportController = new ReportController();
            AddressDTO address = new AddressDTO("15", "Bulevar Cara Lazara", "Skoplje", "Severna Makedonija", "17954");
            Director = new DirectorDTO(address,"Pera", "Peric", "0102031234567", "012/173212", "Male", new DateTime(1985, 11, 5), 13000, null, null, "pera@makedonac.nmac", "pass", "Klinicki Centar Vojvodina");
         
            Propositions = new ObservableCollection<PropositionDTO>();
            Propositions.Add(new PropositionDTO(1,"Berodual","Berodual je ...", "Odobren",5,2));
            Propositions.Add(new PropositionDTO(2,"Promazepam", "Promazepam sluzi za ...", "Odbijen",3,7));
            Propositions.Add(new PropositionDTO(3,"Febricet", "Febricet je valjda za temperaturu, Dr. Kon aj proveri", "Odobren",3,0));
            Propositions.Add(new PropositionDTO(4,"Strepsils", "Tablete za upalu grla", "Odobren",6,2));
            Propositions.Add(new PropositionDTO(5,"Venospas", "Revolucionarno lecenje ozoniranjem krvi", "U razmatranju",1,1));
            Propositions.Add(new PropositionDTO(5, "ZdravkoHerbiko", "Sirup za grlo", "Odbijen", 1, 8));


            Employees = new ObservableCollection<EmployeeDTO>();
            Employees.Add(new EmployeeDTO(address, "Sima", "Paroski", "0412631232567", "022/353452", "Male", new DateTime(1969, 6, 24), 24000, null, null, "simo@gmail.com", "sifria1","Klinicko Centar Vojvodina"));
            Employees.Add(new EmployeeDTO(address, "Humus", "Dumus", "05553331232567", "028/352352", "Female", new DateTime(1969, 6, 24), 23000, null, null, "simo@gmail.com", "sifria1","Klinicko Centar Vojvodina"));
            Employees.Add(new EmployeeDTO(address, "Petar", "Gringovic", "0412631232567", "022/353652", "Male", new DateTime(1969, 6, 24), 28000, null, null, "simo@gmail.com", "sifria1", "Klinicko Centar Vojvodina"));
            Employees.Add(new EmployeeDTO(address, "Slavica", "Bubregovic", "0412631232567", "022/253452", "Female", new DateTime(1980, 6, 24), 2200, null, null, "simo@gmail.com", "sifria1","Klinicko Centar Vojvodina"));


            Equipment = new ObservableCollection<EquipmentDTO>();
            Magacin = new RoomDTO(0,RoomType.hospitalRoom,"magacin","");
            Equipment.Add(new EquipmentDTO(1,"Sto", "Namestaj", "Ovo je sto ima cetiri noge i na njega se stavljaju stvari", Magacin));
            Equipment.Add(new EquipmentDTO(2,"Stolica", "Namestaj", "Ovo je stolica, ima cetiri noge i na njoj se sedi", Magacin));
            Equipment.Add(new EquipmentDTO(3,"Operacioni sto", "Oprema", "Model XYZ,...", Magacin));
            Equipment.Add(new EquipmentDTO(4,"Vrata", "Infrastuktura", "Open Sesame", Magacin));
            Equipment.Add(new EquipmentDTO(5,"Respirator", "Donacija", "Mehanicko disanje???", Magacin));


            MedicalConsumables = new ObservableCollection<MedicalConsumableDTO>();
            MedicalConsumables.Add(new MedicalConsumableDTO(1, "Gaza", "zavoj", "zavoj je izmislio Vasko Popa...", 23));
            MedicalConsumables.Add(new MedicalConsumableDTO(2, "Hanzaplast", "zavoj", "zavoj je izmislio Vasko Popa...", 16));
            MedicalConsumables.Add(new MedicalConsumableDTO(3, "Hidrogen", "rastvor", "zavoj je izmislio Vasko Popa...", 18));
            MedicalConsumables.Add(new MedicalConsumableDTO(4, "Fizioloski rastvor", "rastvor", "zavoj je izmislio Vasko Popa...", 5));


            Medicine = new ObservableCollection<MedicineDTO>();
            Medicine.Add(new MedicineDTO(5, "Berodual", "kortikosteroid", "zavoj je izmislio Vasko Popa...", 23,"","intravenozno",false));
            Medicine.Add(new MedicineDTO(6, "Probiotik Ivancic&sons", "probiotik", "zavoj je izmislio Vasko Popa...", 16, "", "oralno", false));
            Medicine.Add(new MedicineDTO(7, "Fervex", "prasak", "zavoj je izmislio Vasko Popa...", 18, "", "", true));
            Medicine.Add(new MedicineDTO(8, "Zufiofilum", "antibiotik", "zavoj je izmislio Vasko Popa...", 5, "", "", true));


            RoomList = new ObservableCollection<RoomDTO>();
            RoomDTO tester = new RoomDTO(12, RoomType.hospitalRoom, "Intenzivna nega", "4");
            AppointmentDTO testapp = new AppointmentDTO(1,new DateTime(2020,6,12,7,45,0), new DateTime(2020, 6, 12, 8, 20, 0),tester);
            tester.Appointments.Add(testapp);
            RoomList.Add(tester);
            RoomList.Add(new RoomDTO(24, RoomType.operationHall, "Kardiovaskularna", "2"));
            RoomList.Add(new RoomDTO(17, RoomType.medicalRoom, "Pregledi", "1"));
            RoomList.Add(new RoomDTO(5, RoomType.hospitalRoom, "Intenzivna nega", "3"));
        }

        private void OpenSettingsModal(object sender, RoutedEventArgs e)
        {
            SettingsModal modal = new SettingsModal();
            modal.ShowDialog();
        }

        private void OpenBugReportModal(object sender, RoutedEventArgs e)
        {
            BugReportModal modal = new BugReportModal();
            modal.ShowDialog();
        }

        private void ChangeProfile(object sender, RoutedEventArgs e)
        {
            Save_btn.Visibility = Visibility.Visible; ;
            Cancel_btn.Visibility = Visibility.Visible; ;
            Change_btn.Visibility = Visibility.Hidden;
            email.IsEnabled = true;
            adress.IsEnabled = true;
            dateofbirth.IsEnabled = true;
            hospital.IsEnabled = true;
            jmbg.IsEnabled = true;
        }

        private void CancelProfileChanges(object sender, RoutedEventArgs e)
        {
            Save_btn.Visibility = Visibility.Hidden; ;
            Cancel_btn.Visibility = Visibility.Hidden; ;
            Change_btn.Visibility = Visibility.Visible;
            email.IsEnabled = false;
            adress.IsEnabled = false;
            dateofbirth.IsEnabled = false;
            hospital.IsEnabled = false;
            jmbg.IsEnabled = false;
        }

        private void ConfirmProfileChanges(object sender, RoutedEventArgs e)
        {
            Save_btn.Visibility = Visibility.Hidden; ;
            Cancel_btn.Visibility = Visibility.Hidden; ;
            Change_btn.Visibility = Visibility.Visible;
            email.IsEnabled = false;
            adress.IsEnabled = false;
            dateofbirth.IsEnabled = false;
            hospital.IsEnabled = false;
            jmbg.IsEnabled = false;
        }

        private void OpenEmployeeDataModal(object sender, RoutedEventArgs e)
        {
            
            EmployeeDataModal modal = new EmployeeDataModal(this); //prosledjujemo home window da bi mogli novog zaposlenog da dodamo u listu Employees
            modal.ShowDialog();
        }

        private void OpenEmployeeDetails(object sender, RoutedEventArgs e)
        {
            // SelectedEmployee = (EmployeeDTO)EmployeeList.SelectedItem;
            var btn = sender as Button;
            EmployeeList.SelectedItem = btn.DataContext;
            EmployeesGrid.Visibility = Visibility.Collapsed;
            EmployeeDetailsGrid.Visibility = Visibility.Visible;
        }

        private void OpenEmplyees(object sender, RoutedEventArgs e)
        {
            EmployeeDetailsGrid.Visibility = Visibility.Collapsed;
            EmployeesGrid.Visibility = Visibility.Visible;
        }

       
        private void OpenRooms(object sender, RoutedEventArgs e)
        {
           
            RoomDetails.Visibility = Visibility.Collapsed;
            Rooms.Visibility = Visibility.Visible;
        }

        private void OpenRoomDetails(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            //RoomsList.SelectedItem = btn.DataContext;
            SelectedRoomAppointments = null;
            SelectedRoom = btn.DataContext as RoomDTO;
            Rooms.Visibility = Visibility.Collapsed;
            RoomDetails.Visibility = Visibility.Visible;
        }

        private void OpenEquipmentOrder(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            //EquipmentList.SelectedItem = btn.DataContext;
            OrderEquipmentModal modal = new OrderEquipmentModal(this,(EquipmentDTO)btn.DataContext);
            modal.Show();
        }

        private void OpenMedicineOrder(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            OrderMedicineModal modal = new OrderMedicineModal(this, (MedicineDTO)btn.DataContext);
            modal.Show();
        }

        private void OpenMedicineRegistration(object sender, RoutedEventArgs e)
        {

            RegisterMedicine modal = new RegisterMedicine(this);
            modal.Show();
        }

        private void OpenMedicalConsumableOrder(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;     
            OrderMedicalConsumableModal modal = new OrderMedicalConsumableModal(this, (MedicalConsumableDTO)btn.DataContext);
            modal.Show();
        }

        private void OpenRenovationAppointment(object sender, RoutedEventArgs e)
        {
            RenovationModal modal = new RenovationModal();
            modal.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OpenInventoryManagment(object sender, RoutedEventArgs e)
        {
            InventoryManagmentModal modal = new InventoryManagmentModal();
            modal.Show();
        }

        private void ChangeEmployeeProfile(object sender, RoutedEventArgs e)
        {
            foreach (TextBox textBox in employeeData.Children)
                textBox.IsEnabled = true;
            Save_employee.Visibility = Visibility.Visible;
            Cancel_employee.Visibility = Visibility.Visible;
            Change_employee.Visibility = Visibility.Collapsed;
        }

        private void CloseEmpoyeeProfileChanges(object sender, RoutedEventArgs e)
        {
            foreach (TextBox textBox in employeeData.Children)
                textBox.IsEnabled = false;
            Save_employee.Visibility = Visibility.Collapsed;
            Cancel_employee.Visibility = Visibility.Collapsed;
            Change_employee.Visibility = Visibility.Visible;
        }

        private void Generate_Room_Report(object sender, RoutedEventArgs e)
        {
            string fileType = "pdf";
            string type = "room";
            DateTime beginning = new DateTime();
            DateTime end = new DateTime();

            _reportController.Generate(type, fileType, new TimeInterval(beginning, end));


        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void GenerateAppointmentsForDate(object sender, SelectionChangedEventArgs e)
        {
            if (RoomCalendar.SelectedDate.HasValue && SelectedRoom!=null)
            {
                DateTime date = (DateTime)RoomCalendar.SelectedDate;
              
                SelectedRoomAppointments= new ObservableCollection<AppointmentDTO>();
                List<AppointmentDTO> list = SelectedRoom.Appointments;
                if (list!=null) {
                    foreach (AppointmentDTO app in list)
                        if (app.Beginning.Date.Day == date.Date.Day && app.Beginning.Date.Month == date.Date.Month && app.Beginning.Year == date.Date.Year) //verovatno moze samo .Date=.Date
                        {
                            SelectedRoomAppointments.Add(app);
                        } 
                }
            }

        }
    }
}
