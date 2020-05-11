using Model;
using Project.ItemGenerators;
using Project.Repositories;
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

namespace Project.Views.Secretary
{
    /// <summary>
    /// Interaction logic for ProfileModal.xaml
    /// </summary>
    public partial class ProfileModal : Window
    {
        public Model.Patient selectedPatient;
        public ProfileModal(int id)
        {
            Generators g = new Generators();
            PatientRepository pr = new PatientRepository();
            MedicalAppointmentRepository mr = new MedicalAppointmentRepository();
            selectedPatient = g.GeneratePatient();

            InitializeComponent();
            appointmentHistory.ItemsSource = mr.ReadCSV("../../Data/medicalAppointments.csv");
            listAppointments.ItemsSource = mr.ReadCSV("../../Data/medicalAppointments.csv");
        }
    }
}
