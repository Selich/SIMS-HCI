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
using MaterialDesignThemes.Wpf.Transitions;
using Project.Repositories;
using Project.Views.Tabs;

namespace Project.Views.Secretary
{
    /// <summary>
    /// Interaction logic for DoctorSearchModal.xaml
    /// </summary>
    public partial class DoctorSearchModal : Window
    {
        public SecretaryHomeWindow mainWin;
        private SecretaryCreate secretaryCreate;
        private SecretaryAppointments secretaryAppointments;

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Close();
        }

        public DoctorSearchModal(SecretaryHomeWindow secretaryHomeWindow)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            //listDoctors.ItemsSource = dr.ReadCSV("../../Data/doctors.csv");
            //Speciality_ComboBox.ItemsSource = dr.getTypeOfDoctors();
            //CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listDoctors.ItemsSource);
            //view.Filter = UserFilter;
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        public DoctorSearchModal(SecretaryCreate secretaryCreate)
        {
            this.secretaryCreate = secretaryCreate;
        }

        public DoctorSearchModal(SecretaryAppointments secretaryAppointments)
        {
            this.secretaryAppointments = secretaryAppointments;
        }

        private bool UserFilter(object item)
        {
            return true;
            //if (String.IsNullOrEmpty(patientFilter.Text))
            //    return true;
            //else
            //    //return ((item as DoctorDTO).FirstName.IndexOf(patientFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(listDoctors.ItemsSource).Refresh();
        }
        private void listDoctors_SelectionChanged(object sender, KeyEventArgs e)
        {
            if((e.Key & Key.Enter) == Key.Enter)
            {
                if(listDoctors.SelectedItem != null)
                {
                    //mainWin.selectedDoctor = (Model.Doctor)listDoctors.SelectedItem;
                    //mainWin.drName = listDoctors.SelectedItem.ToString();
                }

            }

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void doctorsList_KeyDown(object sender, KeyboardEventArgs e)
        {
            //selectedDoctor = (Model.Doctor)listDoctors.SelectedItem;
            var list =Application.Current.Windows;
            Window w = new Window();
            foreach (Window win in list)
            {
                if(win.Title == "HomeWindow")
                {
                    w = win;
                    break;
                }
            }
            var label = (Label)w.FindName("drLabel");
            var label2 = (Label)w.FindName("drLabel2");
            var id = (Label)w.FindName("drId");
            ////label.Content = "Dr. " + selectedDoctor.FirstName + " " + selectedDoctor.LastName ;
            //label2.Content = "Dr. " + selectedDoctor.FirstName + " " + selectedDoctor.LastName ;
            //id.Content = selectedDoctor.Id;
            //mainWin.refreshContent();
            this.Hide();

        }
    }
}
