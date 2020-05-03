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
using Model;

namespace Project.Views.Secretary
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
            List<Model.Patient> patients = new List<Model.Patient>();
            patients.Add(new Model.Patient()
            {
                firstName = "Uros", lastName = "Milovanovic", jmbg = "121212222221",
                address = new Address() {city = "Novi Sad", street = "Ulica"}
            });
            patients.Add(new Model.Patient()
            {
                firstName = "Dusan", lastName = "Urosevic", jmbg = "121212222221",
                address = new Address() {city = "Novi Sad", street = "Ulica"}
            });
            listPatients.ItemsSource = patients;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var s = new AppointmentModal();
            s.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var s = new AppointmentModal();
            s.Show();

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Handle_Search(object sender, RoutedEventArgs e)
        {

        }
    }
}
