using Project.Controllers;
using Project.Model;
using Project.Views.Model;
using Project.Views.Secretary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project.Views.Tabs
{
    /// <summary>
    /// Interaction logic for SecretaryCreate.xaml
    /// </summary>
    public partial class SecretaryCreate : System.Windows.Controls.UserControl
    {
        private readonly IController<PatientDTO, long> _patientController;
        App app;
        public SecretaryCreate()
        {
            InitializeComponent();

            app = System.Windows.Application.Current as App;


            // HCI
            ListPatients.ItemsSource = app.patients;
            ListTerms.ItemsSource = app.MedicalAppointments;
            ListRooms.ItemsSource = app.rooms;
            AppointmentType.ItemsSource = app.medicalAppointmentTypes;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListPatients.ItemsSource);
            view.Filter = CombinedFilter;


        }
        private bool CombinedFilter(object item)
            => FirstNameFilter(item) && JMBGFilter( item);
        private bool FirstNameFilter(object item)
          => (String.IsNullOrEmpty(FirstNameSearch_TextBox.Text) ||
            (item as PatientDTO).FirstName.IndexOf(FirstNameSearch_TextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        private bool JMBGFilter(object item)
          => (String.IsNullOrEmpty(JMBGSearch_TextBox.Text) ||
            (item as PatientDTO).Jmbg.IndexOf(FirstNameSearch_TextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        private bool TermFilter(object item)
          => (String.IsNullOrEmpty(JMBGSearch_TextBox.Text) ||
            (item as PatientDTO).Jmbg.IndexOf(FirstNameSearch_TextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);

        private void FirstNameSearch_TextBox_TextChanged(object sender, TextChangedEventArgs e)
            => CollectionViewSource.GetDefaultView(ListPatients.ItemsSource).Refresh();


        private void JMBGSearch_TextBox_TextChanged(object sender, TextChangedEventArgs e)
            => CollectionViewSource.GetDefaultView(ListPatients.ItemsSource).Refresh();


        private void AppointmentType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Cancel_Guest_Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Create_Guest_Button_Click(object sender, RoutedEventArgs e) => new Test().Show();
        private void Feedback_Click(object sender, RoutedEventArgs e) => new FeedbackModal().Show();

        private void Search_Doctor(object sender, RoutedEventArgs e) => new DoctorSearchModal(this).Show();

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (RoomNumber_TextBox.Text == "")
            {
                System.Windows.Forms.MessageBox.Show(
                    "Nije izabrana soba. Da li zelite da Vam sistem sam obezbedi dostupnu sobu?",
                    "Potvrda",
                    MessageBoxButtons.YesNo
                    );

            }
            if (RoomNumber_TextBox.Text == null)
            {
                DialogResult result = System.Windows.Forms.MessageBox.Show(
                    "Nije izabran ni jedan lekar. Da li zelite da Vam sistem sam obezbedi dostupnog lekara?",
                    "Potvrda",
                    MessageBoxButtons.YesNoCancel
                    );
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    var s = new DoctorSearchModal();
                    s.Show();

                }
            }



        }

        private void RoomNumber_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void StartDateTime_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EndDateTime_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListPatients_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Return)
                app.SelectedPatient = (ListPatients.SelectedItem as PatientDTO);
                
        }

        private void DemoButton_Click(object sender, RoutedEventArgs e)
        {
            FirstNameSearch_TextBox.Text = "Petar";
            Thread.Sleep(1000);
            FirstNameSearch_TextBox.Text = "";
            JMBGSearch_TextBox.Text = "1603995212533";
            Thread.Sleep(1000);
            JMBGSearch_TextBox.Text = "";
            Guest_Button.Background =  Brushes.Transparent;
            Thread.Sleep(200);
            Guest_Button.Background =  Brushes.Transparent;
            Thread.Sleep(200);
            Guest_Button.Background =  Brushes.Transparent;
            Thread.Sleep(200);
            Guest_Button.Background =  Brushes.Transparent;
            Thread.Sleep(200);
            

        }
    }
}
