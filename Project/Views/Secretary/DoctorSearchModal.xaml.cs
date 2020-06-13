using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Project.Views.Model;
using Project.Views.Tabs;

namespace Project.Views.Secretary
{
    /// <summary>
    /// Interaction logic for DoctorSearchModal.xaml
    /// </summary>
    public partial class DoctorSearchModal : Window
    {
        App app;
        public List<String> MedicalRoles;

        public DoctorSearchModal()
        {
            this.DataContext = this;
            app = System.Windows.Application.Current as App;
            InitializeComponent();
            DoctorList.ItemsSource = app.doctors;
            MedicalRole_ComboBox.ItemsSource = app.medicalRoles;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(DoctorList.ItemsSource);
            view.Filter = CombinedFilter;

        }

        public DoctorSearchModal(SecretaryCreate secretaryCreate)
        {
            this.DataContext = this;
            app = System.Windows.Application.Current as App;
            InitializeComponent();
            DoctorList.ItemsSource = app.doctors;
            MedicalRole_ComboBox.ItemsSource = app.medicalRoles;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(DoctorList.ItemsSource);
            view.Filter = CombinedFilter;
        }

        private bool FirstNameFilter(object item)
          => (String.IsNullOrEmpty(NameSearch_TextBox.Text) ||
            (item as DoctorDTO).FirstName.IndexOf(NameSearch_TextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        private bool LastNameFilter(object item)
          => (String.IsNullOrEmpty(LastNameSearch_TextBox.Text) ||
            (item as DoctorDTO).LastName.IndexOf(LastNameSearch_TextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        private bool MedicalRoleFilter(object item)
          => (MedicalRole_ComboBox.SelectedItem.ToString().Contains("Sve")) ||
            (item as DoctorDTO).MedicalRole.IndexOf(MedicalRole_ComboBox.SelectedItem.ToString(), StringComparison.OrdinalIgnoreCase) >= 0;

        private bool CombinedFilter(object item)
            => FirstNameFilter(item) &&
               LastNameFilter(item) &&
               MedicalRoleFilter(item);



        private void NameSearch_TextBox_TextChanged(object sender, TextChangedEventArgs e)
            => CollectionViewSource.GetDefaultView(DoctorList.ItemsSource).Refresh();
        private void LastNameSearch_TextBox_TextChanged(object sender, TextChangedEventArgs e)
            => CollectionViewSource.GetDefaultView(DoctorList.ItemsSource).Refresh();


        private void MedicalRole_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
            => CollectionViewSource.GetDefaultView(DoctorList.ItemsSource).Refresh();

        private void DoctorList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                app.SelectedDoctor = (DoctorList.SelectedItem as DoctorDTO);
                //CollectionViewSource.GetDefaultView(createP).Refresh();

                this.Close();

            }
                

        }

        private void DemoButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
