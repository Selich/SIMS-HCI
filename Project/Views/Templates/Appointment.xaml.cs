using Project.Model;
using Project.Views.Secretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Project.Views.Templates
{
    partial class Appointment : ResourceDictionary
    {
        private void Term_Click(object sender, RoutedEventArgs e)
        {
            MedicalAppointment item = (MedicalAppointment)(sender as System.Windows.Controls.Button).DataContext;
            var s = new AppointmentModal(item);
            s.Show();

        }

    }
}
