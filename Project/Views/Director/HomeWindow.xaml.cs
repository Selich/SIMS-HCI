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

namespace Project.Views.Director
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
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
            username.IsEnabled = true;
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
            username.IsEnabled = false;
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
            username.IsEnabled = false;
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
    }
}
