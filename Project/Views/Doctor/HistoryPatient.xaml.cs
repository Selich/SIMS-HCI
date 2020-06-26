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
using Project.Views.Model;
using Project.Model;

namespace Project.Views.Doctor
{
    /// <summary>
    /// Interaction logic for HistoryPatient.xaml
    /// </summary>
    public partial class HistoryPatient : Window
    {
        public App app;

        public HistoryPatient(Model.PatientDTO loggedInPatient)
        {

            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            app = Application.Current as App;

            HistoryPatientList.ItemsSource = app.MedicalAppointmentController.GetAllByPatientID(loggedInPatient.Id);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void HistoryPatientList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AnamnesisPateint.Text = "";
            var selitem = HistoryPatientList.SelectedValue;

            AnamnesisPateint.Text += ((MedicalAppointmentDTO)selitem).Patient.FirstName;
            AnamnesisPateint.Text += " ";
            AnamnesisPateint.Text += ((MedicalAppointmentDTO)selitem).Patient.LastName;
            AnamnesisPateint.Text += " ";
            AnamnesisPateint.Text += ((MedicalAppointmentDTO)selitem).Beginning.ToString();


            if (((MedicalAppointmentDTO)selitem).Anamnesis != null)
            {
                foreach (AnamnesisDTO anamnesis in ((MedicalAppointmentDTO)selitem).Anamnesis)
                    if (anamnesis != null)
                    {
                        AnamnesisPateint.Text += anamnesis.ToString();
                    }
            }
        }
    }//AnamnesisPateint
}
