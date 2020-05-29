using Project.Controllers;
using Project.Model;
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
        public DoctorSearchModal DoctorModal;
        private readonly IController<PatientDTO, long> _patientController;
        public SecretaryCreate()
        {
            DoctorModal = new DoctorSearchModal(this);
            InitializeComponent();


            var app = System.Windows.Application.Current as App;

            dateTimePicker.SelectedDate = DateTime.Today;

            _patientController = app.PatientController;

            ListPatientsCreate.ItemsSource = _patientController.GetAll();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            List_Patients_Create.Visibility = Visibility.Hidden;
            Guest_Button.Visibility = Visibility.Hidden;
            Guest_Account_Create.Visibility = Visibility.Visible;
            Cancel_Button.Visibility = Visibility.Visible;
        }
        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            List_Patients_Create.Visibility = Visibility.Visible;
            Guest_Button.Visibility = Visibility.Visible;
            Guest_Account_Create.Visibility = Visibility.Hidden;
            Cancel_Button.Visibility = Visibility.Hidden;
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if(roomFilter.Text == "")
            {
                System.Windows.Forms.MessageBox.Show(
                    "Nije izabran ni jedna soba. Da li zelite da Vam sistem sam obezbedi dostupnu sobu?",
                    "Potvrda",
                    MessageBoxButtons.YesNo
                    );

            }
            if(drLabel2.Content == null)
            {
                DialogResult result = System.Windows.Forms.MessageBox.Show(
                    "Nije izabran ni jedan lekar. Da li zelite da Vam sistem sam obezbedi dostupnog lekara?",
                    "Potvrda",
                    MessageBoxButtons.YesNoCancel
                    );
                if(result == System.Windows.Forms.DialogResult.No)
                {
                    var s = new DoctorSearchModal(this);
                    s.Show();

                }
            }



        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            drLabel2.Content = null;

        }

        private void Feedback_Click(object sender, RoutedEventArgs e)
        {
            var s = new FeedbackModal();
            s.Show();

        }
        private void RoomFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            //CollectionViewSource.GetDefaultView(listRoom.ItemsSource).Refresh();
        }
        private void TxtFilterCreate_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            //CollectionViewSource.GetDefaultView(listPatientsCreate.ItemsSource).Refresh();
        }

        private void Search_Doctor(object sender, RoutedEventArgs e) => DoctorModal.Show();

        private void DatePick_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
