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
        public DoctorSearchModal()
        {
            DoctorRepository dr = new DoctorRepository();
            InitializeComponent();
            listPatients.ItemsSource = dr.ReadCSV("../../Data/doctors.csv");
            Speciality_ComboBox.ItemsSource = dr.getTypeOfDoctors();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listPatients.ItemsSource);
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
            CollectionViewSource.GetDefaultView(listPatients.ItemsSource).Refresh();
        }

        private void Select_Doctor(object sender, EventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
