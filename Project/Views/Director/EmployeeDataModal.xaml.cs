using Project.Views.Model;
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

namespace Project.Views.Director
{
    /// <summary>
    /// Interaction logic for EmployeeDataModal.xaml
    /// </summary>
    public partial class EmployeeDataModal : Window
    {
        public string Email { get; set; }

        public string Address { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Jmbg { get; set; }

        public string Hospital { get; set; }

        public string DateOfBirth { get; set; }
        //public static long newEmployeeID=100; ?????
        public HomeWindow Home { get; set; }
        public EmployeeDataModal(HomeWindow home)
        {
            InitializeComponent();
            this.DataContext = this;
            this.Home = home;

        }

        private void SaveEmployeeDataChanges(object sender, RoutedEventArgs e)
        {
            string Type = NewEmployeeType.SelectedValue.ToString();
            string Role = NewEmployeeRole.SelectedValue.ToString();
            string FirstName = NewEmployeeFirstName.Text;
            string LastName = NewEmployeeLastName.Text;
            string Email = NewEmployeeEmail.Text;
            string Jmbg = NewEmployeeJmbg.Text;
            string Hospital = NewEmployeeHospital.Text;

            string[] splitAdress = NewEmployeeAddress.Text.Split(',');
            if(splitAdress.Length!=3)
            {
                MessageBox.Show("Nije dobar format adrese");
                    return;
            }    
            AddressDTO EmployeeAddress = new AddressDTO(splitAdress[0], splitAdress[1], splitAdress[2], null, null);

            string[] splitDate = NewEmployeeDateOfBirth.Text.Split('/');
            if (splitDate.Length != 3)
            {
                MessageBox.Show("Nije dobar format datuma");
                return;
            }
            DateTime EmployeeDate = new DateTime(Int32.Parse(splitDate[2]), Int32.Parse(splitDate[1]),Int32.Parse(splitDate[0]));

            if (Type.Equals("Lekar"))
            {
                DoctorDTO doctor = new DoctorDTO();
                doctor.MedicalRole = Role;
                doctor.Address = EmployeeAddress;
                doctor.DateOfBirth = EmployeeDate;
                doctor.FirstName = FirstName;
                doctor.LastName = LastName;
                doctor.Email = Email;
                doctor.Jmbg = Jmbg;
                doctor.Hospital = Hospital;
                Home.Employees.Add(doctor);
                Home.VisibleEmployees.Add(doctor);
                Home.Doctors.Add(doctor);
            }
            else
            {
                SecretaryDTO secretary = new SecretaryDTO();
                secretary.Address = EmployeeAddress;
                secretary.DateOfBirth = EmployeeDate;
                secretary.FirstName = FirstName;
                secretary.LastName = LastName;
                secretary.Email = Email;
                secretary.Jmbg = Jmbg;
                secretary.Hospital = Hospital;
                Home.Employees.Add(secretary);
                Home.VisibleEmployees.Add(secretary);
                Home.Secretaries.Add(secretary);

            }

            this.Close();
        }

        private void CancelEmployeeDataChanges(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
