using Project.Views.Model;
using Project.Views.Secretary;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project.Views.Tabs
{
    /// <summary>
    /// Interaction logic for SecretaryPatients.xaml
    /// </summary>
    public partial class SecretaryPatients : UserControl
    {
        App app;
        public SecretaryPatients()
        {

            InitializeComponent();
            app = Application.Current as App;

            PatientList.ItemsSource = app.patients;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(PatientList.ItemsSource);
            view.Filter = CombinedFilter;
        }
        private bool CombinedFilter(object item)
            => FirstNameFilter(item) && JMBGFilter(item) && GradFilter(item) && GuestFilter(item);

        private bool FirstNameFilter(object item)
          => (String.IsNullOrEmpty(PatientSearch_TextBox.Text) ||
            (item as PatientDTO).FirstName.IndexOf(PatientSearch_TextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);

        private bool JMBGFilter(object item)
          => (String.IsNullOrEmpty(JMBGSearch_TextBox.Text) ||
            (item as PatientDTO).Jmbg.IndexOf(JMBGSearch_TextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        private bool AddressFilter(object item)
          => (String.IsNullOrEmpty(AddressSearch_TextBox.Text) ||
            (item as PatientDTO).Jmbg.IndexOf(AddressSearch_TextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        private bool GradFilter(object item)
          => (String.IsNullOrEmpty(AddressSearch_TextBox.Text) ||
            (item as PatientDTO).Jmbg.IndexOf(AddressSearch_TextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        private bool GuestFilter(object item)
          => (GuestFilter_CheckBox.IsChecked == false) ||
            ((item as PatientDTO).Email.Equals("") == false);

        private void JMBGSearch_TextBox_TextChanged(object sender, TextChangedEventArgs e)
            => CollectionViewSource.GetDefaultView(PatientList.ItemsSource).Refresh();


        private void AddressSearch_TextBox_TextChanged(object sender, TextChangedEventArgs e)
            => CollectionViewSource.GetDefaultView(PatientList.ItemsSource).Refresh();

        private void GuestFilter_CheckBox_Click(object sender, RoutedEventArgs e)
            => CollectionViewSource.GetDefaultView(PatientList.ItemsSource).Refresh();

        private void PatientSearch_TextBox_TextChanged(object sender, TextChangedEventArgs e)
            => CollectionViewSource.GetDefaultView(PatientList.ItemsSource).Refresh();

        private void Feedback_Click(object sender, RoutedEventArgs e) => new FeedbackModal().Show();

        private void CreatePatient_Click(object sender, RoutedEventArgs e) => new RegisterPatient().Show();

    }
}
