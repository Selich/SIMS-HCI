using Project.Model;
using Project.Views.Model;
using Project.Views.Secretary;
using Project.Views.Templates;
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
    /// Interaction logic for SecretaryAppointments.xaml
    /// </summary>
    public partial class SecretaryAppointments : System.Windows.Controls.UserControl
    {
        App app;
        public SecretaryAppointments()
        {
            InitializeComponent();
            DataContext = this;
            app = System.Windows.Application.Current as App;
            CurrentDoctor.Content = app.SelectedDoctor;
            nextAppointment.Content = app.MedicalAppointments[0];


        }
        private void Search_Doctor(object sender, RoutedEventArgs e) => new DoctorSearchModal(this).Show();
        private void Feedback_Click(object sender, RoutedEventArgs e) => new FeedbackModal().Show();
        private void Button_Click(object sender, RoutedEventArgs e) => new SecretaryCreateModal().Show();
        private void GenerateReportButton_Click(object sender, RoutedEventArgs e) => new SecretaryGenerateReport().Show();
    }
}
