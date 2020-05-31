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
using Project.Model;

namespace Project.Views.Patient
{
    /// <summary>
    /// Interaction logic for RegisterPatient.xaml
    /// </summary>
    public partial class RegisterPatient : Window
    {
        public Project.Model.Patient registeringPatient
        {
            get;
            set;
        }
        public RegisterPatient()
        {
            InitializeComponent();
            this.DataContext = this;
            //Profile
            registeringPatient = new Project.Model.Patient() { FirstName = "Uros", LastName = "Milovanovic",
                DateOfBirth = new DateTime(1998, 8, 25), Email = "urke123@gmail.com", Gender = "Male",
                InsurenceNumber = "1234567", Jmbg = "1234567890", TelephoneNumber = "06551232123",
                Address = new Project.Model.Address()
                { City = "Novi Sad", Country = "Serbia", Number = "25", PostCode = "21000", Street = "Petra Petrovica" } };

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
