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
        public ObservableCollection<Project.Model.MedicalAppointment> Appoitments
        {
            get;
            set;
        }
        public HomeWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Room tempRoom = new Project.Model.Room() { floor = "One", id = 1, ward="Check" };
            Appoitments = new ObservableCollection<Project.Model.MedicalAppointment>();
            Appoitments.Add(new MedicalAppointment() { Room = tempRoom, Beginning = new DateTime(2020, 5, 10, 15, 0, 0), type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 10, 15, 30, 0) });
            Appoitments.Add(new MedicalAppointment() { Room = tempRoom, Beginning = new DateTime(2020, 5, 11, 18, 0, 0), type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 11, 18, 30, 0) });
            Appoitments.Add(new MedicalAppointment() { Room = tempRoom, Beginning = new DateTime(2020, 5, 12, 15, 0, 0), type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 12, 15, 30, 0) });
            Appoitments.Add(new MedicalAppointment() { Room = tempRoom, Beginning = new DateTime(2020, 5, 13, 15, 0, 0), type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 13, 15, 30, 0) });
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
    }
}
