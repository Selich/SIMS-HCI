using Controller;
using Model;
using Project.ItemGenerators;
using Project.Repositories;
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
            Generators gen = new Generators();
            InitializeComponent();

            selectedAppointment.Content = app;
            listDoctors.ItemsSource = app.doctors;
            listAllDoctors.ItemsSource = gen.GenerateDoctors(10);

        }

        private void Change_Doctors(object sender, RoutedEventArgs e)
        {
            search.Visibility = Visibility.Visible;
            kodLekara.Visibility = Visibility.Hidden;
            Change_Doctor_Button.Visibility = Visibility.Hidden;
            listDoctors.Visibility = Visibility.Hidden;
            listAllDoctors.Visibility = Visibility.Visible;
            Cancel_Change_Doctor_Button.Visibility = Visibility.Visible;


        }
        private void Cancel_Change_Doctors(object sender, RoutedEventArgs e)
        {
            search.Visibility = Visibility.Hidden;
            kodLekara.Visibility = Visibility.Visible;
            Change_Doctor_Button.Visibility = Visibility.Visible;
            listAllDoctors.Visibility = Visibility.Hidden;
            listDoctors.Visibility = Visibility.Visible;
            Cancel_Change_Doctor_Button.Visibility = Visibility.Hidden;

        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            MedicalAppointment item = (MedicalAppointment)(sender as System.Windows.Controls.Button).DataContext;
            var id = item.patient.id;
            var s = new ProfileModal(id);
            s.Show();

        }
        private void Add_Doctor_Click(object sender, RoutedEventArgs e)
        {
            Model.Doctor item = (Model.Doctor)(sender as System.Windows.Controls.Button).DataContext;
            MessageBox.Show("Da li ste sigurni da zelite da dodate Dr." + item.firstName + " " + item.lastName + " u termin?", "Potvrda", MessageBoxButton.OKCancel);
            listAllDoctors.Visibility = Visibility.Hidden;
            listDoctors.Visibility = Visibility.Visible;
            Change_Doctor_Button.Visibility = Visibility.Visible;
            Cancel_Change_Doctor_Button.Visibility = Visibility.Hidden;


        }
        private void txtFilter_TextChanged(object sended, RoutedEventArgs e)
        {

        }
    }
}
