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

namespace Project.Views.Director
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
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

    public HomeWindow()
        {
           
            InitializeComponent();
            this.DataContext = this;
            var app = Application.Current as App;

            _reportController = new ReportController();
            AddressDTO address = new AddressDTO("15", "Bulevar Cara Lazara", "Skoplje", "Severna Makedonija", "17954");
            Director = new DirectorDTO(address,"Pera", "Peric", "0102031234567", "012/173212", "Male", new DateTime(1985, 11, 5), 13000, null, null, "pera@makedonac.nmac", "pass");
            Director.Hospital = "Klinicki Centar Vojvodina";
            Propositions = new ObservableCollection<PropositionDTO>();
            Propositions.Add(new PropositionDTO("Berodual","JabadabaduOpisjuemLekNeki", "Odobren"));
            Propositions.Add(new PropositionDTO("Promazepam", "JabadabaduOpisjuemLekNeki", "Odbijen"));
            Propositions.Add(new PropositionDTO("Febricet", "JabadabaduOpisjuemLekNeki", "Odobren"));
            Propositions.Add(new PropositionDTO("Strepsils", "JabadabaduOpisjuemLekNeki", "Odobren"));
            Propositions.Add(new PropositionDTO("Venospas", "JabadabaduOpisjuemLekNeki", "U razmatranju"));

            Employees = new ObservableCollection<EmployeeDTO>();
            Employees.Add(new EmployeeDTO(address, "Sima", "Paroski", "0412631232567", "022/353452", "Male", new DateTime(1969, 6, 24), 24000, null, null, "simo@gmail.com", "sifria1"));
            Employees.Add(new EmployeeDTO(address, "Humus", "Dumus", "05553331232567", "028/352352", "Female", new DateTime(1969, 6, 24), 23000, null, null, "simo@gmail.com", "sifria1"));
            Employees.Add(new EmployeeDTO(address, "Petar", "Gringovic", "0412631232567", "022/353652", "Male", new DateTime(1969, 6, 24), 28000, null, null, "simo@gmail.com", "sifria1"));
            Employees.Add(new EmployeeDTO(address, "Slavica", "Bubregovic", "0412631232567", "022/253452", "Female", new DateTime(1980, 6, 24), 2200, null, null, "simo@gmail.com", "sifria1"));

            Equipment = new ObservableCollection<EquipmentDTO>();
            RoomDTO room = new RoomDTO(0,RoomType.hospitalRoom,"magacin","");
            Equipment.Add(new EquipmentDTO("Sto", "Namestaj", "Ovo je sto ima cetiri noge i na njega se stavljaju stvari", room));
            Equipment.Add(new EquipmentDTO("Stolica", "Namestaj", "Ovo je stolica, ima cetiri noge i na njoj se sedi", room));
            Equipment.Add(new EquipmentDTO("Operacioni sto", "Oprema", "Model XYZ,...", room));
            Equipment.Add(new EquipmentDTO("Vrata", "Infrastuktura", "Open Sesame", room));
            Equipment.Add(new EquipmentDTO("Respirator", "Donacija", "Mehanicko disanje???", room));

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
            RoomList.Add(new RoomDTO(12,RoomType.hospitalRoom,"Intenzivna nega","4"));
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
            EmployeeDataModal modal = new EmployeeDataModal();
            modal.ShowDialog();
        }

        private void OpenEmployeeDetails(object sender, RoutedEventArgs e)
        {
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
            Rooms.Visibility = Visibility.Collapsed;
            RoomDetails.Visibility = Visibility.Visible;
        }

        private void OpenEquipmentOrder(object sender, RoutedEventArgs e)
        {
            OrderEquipmentModal modal = new OrderEquipmentModal();
            modal.Show();
        }

        private void OpenMedicineOrder(object sender, RoutedEventArgs e)
        {
            OrderMedicineModal modal = new OrderMedicineModal();
            modal.Show();
        }

        private void OpenMedicineRegistration(object sender, RoutedEventArgs e)
        {
            RegisterMedicine modal = new RegisterMedicine();
            modal.Show();
        }

        private void OpenMedicalConsumableOrder(object sender, RoutedEventArgs e)
        {
            OrderMedicalConsumableModal modal = new OrderMedicalConsumableModal();
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
    }
}
