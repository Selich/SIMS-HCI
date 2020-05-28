using Controller;
using Project.Model;
using Project.Repositories;
using Project.Views.Model;
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

namespace Project.Views.Secretary
{
    /// <summary>
    /// Interaction logic for AppointmentModal.xaml
    /// </summary>
    public partial class AppointmentModal : Window
    {
        public AppointmentModal(MedicalAppointment app)
        {
            //Generators gen = new Generators();
            //WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            //InitializeComponent();

            //selectedAppointment.Content = app;
            //listDoctors.ItemsSource = app.doctors;
            //listAllDoctors.ItemsSource = gen.GenerateDoctors(10);
            //CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listAllDoctors.ItemsSource);
            //view.Filter = DoctorFilter;
            //this.PreviewKeyDown += new KeyEventHandler(HandleEsc);

        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Close();
        }

        private bool DoctorFilter(object item)
        {
            if (String.IsNullOrEmpty(search.Text))
                return true;
            else
                return ((item as User).FirstName.IndexOf(search.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private void searchDoctor_TxtChanged(object sended, RoutedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(listAllDoctors.ItemsSource).Refresh();

        }

        private void Change_Doctors(object sender, RoutedEventArgs e)
        {
            search.Visibility = Visibility.Visible;
            Change_Doctor_Button.Visibility = Visibility.Hidden;
            listDoctors.Visibility = Visibility.Hidden;
            listAllDoctors.Visibility = Visibility.Visible;
            Cancel_Change_Doctor_Button.Visibility = Visibility.Visible;


        }
        private void Cancel_Change_Doctors(object sender, RoutedEventArgs e)
        {
            search.Visibility = Visibility.Hidden;
            Change_Doctor_Button.Visibility = Visibility.Visible;
            listAllDoctors.Visibility = Visibility.Hidden;
            listDoctors.Visibility = Visibility.Visible;
            Cancel_Change_Doctor_Button.Visibility = Visibility.Hidden;

        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            MedicalAppointment item = (MedicalAppointment)(sender as System.Windows.Controls.Button).DataContext;
            var id = item.patient.Id;
            var s = new ProfileModal(id);
            s.Show();

        }
        private void Add_Doctor_Click(object sender, RoutedEventArgs e)
        {
            DoctorDTO item = (DoctorDTO)(sender as System.Windows.Controls.Button).DataContext;
            MessageBox.Show("Da li ste sigurni da zelite da dodate Dr." + item.FirstName + " " + item.LastName + " u termin?", "Potvrda", MessageBoxButton.OKCancel);
            listAllDoctors.Visibility = Visibility.Hidden;
            listDoctors.Visibility = Visibility.Visible;
            Change_Doctor_Button.Visibility = Visibility.Visible;
            Cancel_Change_Doctor_Button.Visibility = Visibility.Hidden;


        }
        private void txtFilter_TextChanged(object sended, RoutedEventArgs e)
        {

        }
        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            room.IsEnabled = true;
            timeFrom.IsEnabled = true;
            timeTo.IsEnabled = true;
            datePicker.IsEnabled = true;
            description.IsEnabled = true;
            appointmentType.IsEnabled = true;
            IzmeniCancel.Visibility = Visibility.Visible;
            Izmeni.Visibility = Visibility.Hidden;

        }
        private void Izmeni_Cancel_Click(object sender, RoutedEventArgs e)
        {
            bool state = false;
            room.IsEnabled = state;
            timeFrom.IsEnabled = state;
            timeTo.IsEnabled = state;
            datePicker.IsEnabled = state;
            description.IsEnabled = state;
            appointmentType.IsEnabled = state;
            IzmeniCancel.Visibility = Visibility.Hidden;
            Izmeni.Visibility = Visibility.Visible;
        }
    }
}
