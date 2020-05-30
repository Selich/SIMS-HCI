using Project.Model;
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

namespace Project.Views.Patient
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public ObservableCollection<Model.MedicalAppointmentDTO> Appoitments
        {
            get;
            set;
        }
        public ObservableCollection<Model.MedicalAppointmentDTO> PastAppoitments
        {
            get;
            set;
        }

        public Model.Patient LoggedInPatient
        {
            get;
            set;
        }

        public HomeWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            //Appoitments
            Room tempRoom = new Model.Room() { floor = "One", id = 4, ward="Check" };
            Appoitments = new ObservableCollection<Model.MedicalAppointmentDTO>();
            Appoitments.Add(new MedicalAppointmentDTO() { room = tempRoom, beginning = new DateTime(2020, 5, 10, 15, 0, 0), type = MedicalAppointmentType.examination, end = new DateTime(2020, 5, 10, 15, 30, 0) });
            Appoitments.Add(new MedicalAppointmentDTO() { room = tempRoom, beginning = new DateTime(2020, 5, 11, 18, 0, 0), type = MedicalAppointmentType.examination, end = new DateTime(2020, 5, 11, 18, 30, 0) });
            Appoitments.Add(new MedicalAppointmentDTO() { room = tempRoom, beginning = new DateTime(2020, 5, 12, 15, 0, 0), type = MedicalAppointmentType.examination, end = new DateTime(2020, 5, 12, 15, 30, 0) });
            Appoitments.Add(new MedicalAppointmentDTO() { room = tempRoom, beginning = new DateTime(2020, 5, 13, 15, 0, 0), type = MedicalAppointmentType.examination, end = new DateTime(2020, 5, 13, 15, 30, 0) });
            Appoitments.Add(new MedicalAppointmentDTO() { room = tempRoom, beginning = new DateTime(2020, 5, 14, 11, 0, 0), type = MedicalAppointmentType.operation, end = new DateTime(2020, 5, 14, 11, 30, 0) });
            Appoitments.Add(new MedicalAppointmentDTO() { room = tempRoom, beginning = new DateTime(2020, 5, 15, 14, 0, 0), type = MedicalAppointmentType.operation, end = new DateTime(2020, 5, 15, 14, 30, 0) });


            //History
            Model.Doctor tempDoctor = new Model.Doctor() {FirstName = "Filip Zdelar" };
            List<Model.Doctor> tempDoctors = new List<Model.Doctor>();
            tempDoctors.Add(tempDoctor);

            PastAppoitments = new ObservableCollection<Model.MedicalAppointmentDTO>();
            PastAppoitments.Add(new MedicalAppointmentDTO() { room = tempRoom, beginning = new DateTime(2020, 5, 1, 15, 0, 0), type = MedicalAppointmentType.examination, end = new DateTime(2020, 5, 1, 15, 30, 0), Doctors = tempDoctors });
            PastAppoitments.Add(new MedicalAppointmentDTO() { room = tempRoom, beginning = new DateTime(2020, 5, 2, 18, 0, 0), type = MedicalAppointmentType.examination, end = new DateTime(2020, 5, 2, 18, 30, 0), Doctors = tempDoctors });
            PastAppoitments.Add(new MedicalAppointmentDTO() { room = tempRoom, beginning = new DateTime(2020, 5, 3, 15, 0, 0), type = MedicalAppointmentType.examination, end = new DateTime(2020, 5, 3, 15, 30, 0), Doctors = tempDoctors });
            PastAppoitments.Add(new MedicalAppointmentDTO() { room = tempRoom, beginning = new DateTime(2020, 5, 4, 15, 0, 0), type = MedicalAppointmentType.examination, end = new DateTime(2020, 5, 4, 15, 30, 0), Doctors = tempDoctors });
            PastAppoitments.Add(new MedicalAppointmentDTO() { room = tempRoom, beginning = new DateTime(2020, 5, 5, 11, 0, 0), type = MedicalAppointmentType.operation, end = new DateTime(2020, 5, 5, 11, 30, 0), Doctors = tempDoctors });
            PastAppoitments.Add(new MedicalAppointmentDTO() { room = tempRoom, beginning = new DateTime(2020, 5, 7, 14, 0, 0), type = MedicalAppointmentType.operation, end = new DateTime(2020, 5, 7, 14, 30, 0), Doctors = tempDoctors });
            //Profile
            Model.Address tempAddress = new Model.Address() { City = "Novi Sad", Country = "Serbia", Number = "25", PostCode = "21000", Street = "Petra Petrovica" };
            LoggedInPatient = new Model.Patient() { FirstName = "Uros", LastName = "Milovanovic", DateOfBirth = new DateTime(1998, 8, 25), Email = "urke123@gmail.com", Gender = "Male", InsurenceNumber = "1234567", Jmbg = "1234567890", TelephoneNumber= "06551232123", Address = new Model.Address() { City = "Novi Sad", Country = "Serbia", Number = "25", PostCode = "21000", Street = "Petra Petrovica" } };
        }

        private void Feedback_Click(object sender, RoutedEventArgs e)
        {
            var s = new Patient.Feedback();
            s.Show();
        }

        private void FAQ_Click(object sender, RoutedEventArgs e)
        {
            var s = new Patient.FAQ();
            s.Show();
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            var s = new Patient.History();
            s.Show();
        }

        private void Doctor_Click(object sender, RoutedEventArgs e)
        {
            var s = new Patient.Doctor();
            s.Show();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            firstName.IsEnabled = true;
            lastName.IsEnabled = true;
            birthDate.IsEnabled = true;
            JMBG.IsEnabled = true;
            insuranceNumber.IsEnabled = true;
            gender.IsEnabled = true;
            country.IsEnabled = true;
            city.IsEnabled = true;
            postCode.IsEnabled = true;
            street.IsEnabled = true;
            number.IsEnabled = true;
            email.IsEnabled = true;
            password.IsEnabled = true;
            buttonSaveChanges.IsEnabled = true;
            buttonEdit.IsEnabled = false;
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            firstName.IsEnabled = false;
            lastName.IsEnabled = false;
            birthDate.IsEnabled = false;
            JMBG.IsEnabled = false;
            insuranceNumber.IsEnabled = false;
            gender.IsEnabled = false;
            country.IsEnabled = false;
            city.IsEnabled = false;
            postCode.IsEnabled = false;
            street.IsEnabled = false;
            number.IsEnabled = false;
            email.IsEnabled = false;
            password.IsEnabled = false;
            buttonSaveChanges.IsEnabled = false;
            buttonEdit.IsEnabled = true;
        }
    }
}
