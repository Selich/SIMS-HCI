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

namespace Project.Views.Secretary
{
    /// <summary>
    /// Interaction logic for DoctorSearchModal.xaml
    /// </summary>
    public partial class DoctorSearchModal : Window
    {
        public HomeWindow mainWin;
        public Model.Doctor selectedDoctor;

        public DoctorSearchModal(HomeWindow mainWin)
        {
            DoctorRepository dr = new DoctorRepository();
            this.mainWin = mainWin;
            InitializeComponent();
            listDoctors.ItemsSource = dr.ReadCSV("../../Data/doctors.csv");
            Speciality_ComboBox.ItemsSource = dr.getTypeOfDoctors();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listDoctors.ItemsSource);
            view.Filter = UserFilter;
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(patientFilter.Text))
                return true;
            else
                return ((item as Model.Doctor).firstName.IndexOf(patientFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
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
                    mainWin.selectedDoctor = (Model.Doctor)listDoctors.SelectedItem;
                    mainWin.drName = listDoctors.SelectedItem.ToString();
                }

            }

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void doctorsList_KeyDown(object sender, KeyboardEventArgs e)
        {
            selectedDoctor = (Model.Doctor)listDoctors.SelectedItem;
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
            label.Content = "Dr. " + selectedDoctor.firstName + " " + selectedDoctor.lastName ;
            label2.Content = "Dr. " + selectedDoctor.firstName + " " + selectedDoctor.lastName ;
            id.Content = selectedDoctor.id;
            mainWin.refreshContent();
            this.Hide();

        }
    }
}
