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

namespace Project.Views.Patient
{
    /// <summary>
    /// Interaction logic for RateAppointment.xaml
    /// </summary>
    public partial class RateAppointment : Window
    {
        public MedicalAppointmentDTO ReviewAppointment { get; set; }

        public RateAppointment(MedicalAppointmentDTO appointment)
        {
            InitializeComponent();
            this.DataContext = this;
            ReviewAppointment = appointment;
        }
    }
}
