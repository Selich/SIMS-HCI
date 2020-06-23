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
using System.Windows.Shapes;


namespace Project.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public string Email { get; set; }
        App app;
        public LoginWindow()
        {
            app = System.Windows.Application.Current as App;
            InitializeComponent();


            //for validation to work
            this.DataContext = this;

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var role = app.AuthenticationController.Login(Email, PasswordTextBox.Password);
            switch (role)
            {
                case "Director": new Director.HomeWindow().Show(); break;
                case "Secretary": new Secretary.SecretaryHomeWindow().Show(); break;
                case "Doctor": new Doctor.HomeWindow().Show(); break;
                case "Patient": new Patient.HomeWindow().Show(); break;
                default: System.Windows.Forms.MessageBox.Show("Neuspešno prijavljivanje", "Neuspešno prijavljivanje", MessageBoxButtons.OK); break;
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var s = new Patient.RegisterPatient();
            s.Show();

        }
    }
}
