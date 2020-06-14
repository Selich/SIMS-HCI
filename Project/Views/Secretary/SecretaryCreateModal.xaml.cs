using Project.Controllers;
using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Project.Views.Secretary
{
    /// <summary>
    /// Interaction logic for SecretaryCreateModal.xaml
    /// </summary>
    public partial class SecretaryCreateModal : Window
    {
        private readonly IController<PatientDTO, long> _patientController;
        public int _someVal = 0;
        private readonly CancellationTokenSource cts = new CancellationTokenSource();

        App app;
        public SecretaryCreateModal()
        {
            InitializeComponent();

            app = System.Windows.Application.Current as App;

            //StartDateTime.SelectedDate = DateTime.Now;
            //EndDateTime.SelectedDate = DateTime.Now.AddMinutes(30);

            //_patientController = app.PatientController;
            //ListPatients.ItemsSource = _patientController.GetAll();

            SelectedDate.SelectedDate = DateTime.Now;
            // HCI
            ListPatients.ItemsSource = app.patients;
            ListTerms.ItemsSource = app.MedicalAppointments;
            ListRooms.ItemsSource = app.rooms;
            AppointmentType.ItemsSource = app.medicalAppointmentTypes;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListPatients.ItemsSource);
            CollectionView termView = (CollectionView)CollectionViewSource.GetDefaultView(ListTerms.ItemsSource);
            CollectionView roomView = (CollectionView)CollectionViewSource.GetDefaultView(ListRooms.ItemsSource);
            view.Filter = CombinedFilter;
            termView.Filter = TermFilter;
            roomView.Filter = RoomFilter;


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
          => (String.IsNullOrEmpty(SelectedDate.SelectedDate.ToString()) ||
            (item as MedicalAppointmentDTO).Beginning.ToString().IndexOf(SelectedDate.SelectedDate.ToString(), StringComparison.OrdinalIgnoreCase) >= 0);

        private bool RoomFilter(object item)
          => (String.IsNullOrEmpty(RoomSearch_TextBox.Text) ||
            (item as RoomDTO).Id.ToString().IndexOf(RoomSearch_TextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);

        private void FirstNameSearch_TextBox_TextChanged(object sender, TextChangedEventArgs e)
            => CollectionViewSource.GetDefaultView(ListPatients.ItemsSource).Refresh();


        private void JMBGSearch_TextBox_TextChanged(object sender, TextChangedEventArgs e)
            => CollectionViewSource.GetDefaultView(ListPatients.ItemsSource).Refresh();

        private void TermSearch_TextBox_TextChanged(object sender, TextChangedEventArgs e)
            => CollectionViewSource.GetDefaultView(ListPatients.ItemsSource).Refresh();
        private void RoomSearch_TextBox_TextChanged(object sender, TextChangedEventArgs e)
            => CollectionViewSource.GetDefaultView(ListRooms.ItemsSource).Refresh();
        private void SelectedDate_SelectedDatesChanged(object sender, SelectionChangedEventArgs e) { }
            //=> CollectionViewSource.GetDefaultView(ListTerms.ItemsSource).Refresh();

        private void AppointmentType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Cancel_Guest_Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Create_Guest_Button_Click(object sender, RoutedEventArgs e) => new RegisterGuest().Show();
        private void Feedback_Click(object sender, RoutedEventArgs e) => new FeedbackModal().Show();

        private void Search_Doctor(object sender, RoutedEventArgs e) => new DoctorSearchModal().Show();

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (RoomSearch_TextBox.Text == "")
            {
                System.Windows.Forms.MessageBox.Show(
                    "Nije izabrana soba. Da li zelite da Vam sistem sam obezbedi dostupnu sobu?",
                    "Potvrda",
                    MessageBoxButtons.YesNo
                    );

            }
            if (RoomSearch_TextBox.Text == null)
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
        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Space) _someVal--;
        }
        private async void DemoButton_Click(object sender, RoutedEventArgs e)
        {
            _someVal++;
            while (_someVal == 1)
            {

            Brush colour = Guest_Button.Background;
            await Task.Delay(1000);
            FirstNameSearch_TextBox.Text = "Petar";
            await Task.Delay(1000);
            FirstNameSearch_TextBox.Text = "";
            JMBGSearch_TextBox.Text = "1603995212533";
            await Task.Delay(2000);
            JMBGSearch_TextBox.Text = "";
            await Task.Delay(200);
            Guest_Button.Background =  Brushes.Transparent;
            await Task.Delay(200);
            Guest_Button.Background =  Brushes.White;
            await Task.Delay(200);
            Guest_Button.Background =  colour;
            await Task.Delay(200);
            Guest_Button.Background =  Brushes.Transparent;
            await Task.Delay(200);
            Guest_Button.Background =  Brushes.White;
            await Task.Delay(200);
            Guest_Button.Background =  colour;
            await Task.Delay(200);
            var s = new RegisterGuest();
            s.Show();
            await Task.Delay(2000);
            s.Close();
            await Task.Delay(200);
            AppointmentType.Background = Brushes.Transparent;
            await Task.Delay(200);
            AppointmentType.Background = Brushes.White;
            await Task.Delay(200);
            AppointmentType.Background = Brushes.Transparent;
            await Task.Delay(200);
            AppointmentType.Background = Brushes.White;

            await Task.Delay(200);
            ListTerms.Background = Brushes.Transparent;
            await Task.Delay(200);
            ListTerms.Background = Brushes.White;
            await Task.Delay(200);
            ListTerms.Background = Brushes.Transparent;
            await Task.Delay(200);
            ListTerms.Background = Brushes.White;

            await Task.Delay(200);
            SelectedDate.Background = Brushes.Transparent;
            await Task.Delay(200);
            SelectedDate.Background = Brushes.White;
            await Task.Delay(200);
            SelectedDate.Background = Brushes.Transparent;
            await Task.Delay(200);
            SelectedDate.Background = Brushes.White;
            await Task.Delay(200);

            await Task.Delay(200);
            RoomNumber_TextBox.Text = "135";
            await Task.Delay(200);

            await Task.Delay(200);
            ListRooms.Background = Brushes.Transparent;
            await Task.Delay(200);
            ListRooms.Background = Brushes.White;
            await Task.Delay(200);
            ListRooms.Background = Brushes.Transparent;
            await Task.Delay(200);
            ListRooms.Background = Brushes.White;
            await Task.Delay(200);

            await Task.Delay(200);
            CreateButton.Background = Brushes.Transparent;
            await Task.Delay(200);
            CreateButton.Background = Brushes.White;
            await Task.Delay(200);
            CreateButton.Background =  colour;
            await Task.Delay(200);
            CreateButton.Background = Brushes.Transparent;
            await Task.Delay(200);
            CreateButton.Background = Brushes.White;
            await Task.Delay(200);
            CreateButton.Background =  colour;
            }
            


        }

    }
}
