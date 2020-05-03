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
using Project.Repositories;

namespace Project.Views.Secretary
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    { 
        public static string selectedDoctor { get; set; }
        public HomeWindow()
        {   
            PatientRepository pr = new PatientRepository();
            InitializeComponent();
            listPatients.ItemsSource = pr.ReadCSV("../../Data/patients.csv");
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listPatients.ItemsSource);
            view.Filter = UserFilter;



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

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(patientFilter.Text))
                return true;
            else
                return ((item as User).firstName.IndexOf(patientFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(listPatients.ItemsSource).Refresh();
        }


        private void Handle_Doctor_Search(object sender, TextChangedEventArgs e)
        {

        }

        private void Search_Doctor(object sender, RoutedEventArgs e)
        {
            var s = new DoctorSearchModal();
            s.Show();

        }
    }
}
