using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
using Project.Entity;

namespace Project.Views.Patient
{
    public partial class Doctor : Window
    {
        public DoctorDTO doctor { get; set; }
        public ObservableCollection<MedicalAppointmentDTO> AvailableAppoitments { get; set; }

        public Doctor()
        {
            InitializeComponent();
            this.DataContext = this;



            //list of appotments for this doctor and where the logged in patient is scheguled
            List<MedicalAppointmentDTO> tempAppointments = new List<MedicalAppointmentDTO>();
            RoomDTO tempRoom = new RoomDTO() { floor = "two", type = Model.RoomType.medicalRoom, ward = "op" };
            tempAppointments.Add(new MedicalAppointmentDTO() { room = tempRoom, beginning = new DateTime(2020, 5, 10, 15, 0, 0), type = Model.MedicalAppointmentType.examination, end = new DateTime(2020, 5, 10, 15, 30, 0) });
            tempAppointments.Add(new MedicalAppointmentDTO() { room = tempRoom, beginning = new DateTime(2020, 5, 11, 15, 0, 0), type = Model.MedicalAppointmentType.examination, end = new DateTime(2020, 5, 11, 15, 30, 0) });
            tempAppointments.Add(new MedicalAppointmentDTO() { room = tempRoom, beginning = new DateTime(2020, 5, 12, 15, 0, 0), type = Model.MedicalAppointmentType.examination, end = new DateTime(2020, 5, 12, 15, 30, 0) });
            tempAppointments.Add(new MedicalAppointmentDTO() { room = tempRoom, beginning = new DateTime(2020, 5, 13, 15, 0, 0), type = Model.MedicalAppointmentType.examination, end = new DateTime(2020, 5, 13, 15, 30, 0) });
            tempAppointments.Add(new MedicalAppointmentDTO() { room = tempRoom, beginning = new DateTime(2020, 5, 14, 15, 0, 0), type = Model.MedicalAppointmentType.examination, end = new DateTime(2020, 5, 14, 15, 30, 0) });
            doctor = new DoctorDTO() { Appointments = tempAppointments, FirstName = "Filip", LastName = "Zdelar", AvrageReviewScore = 4.5F};

            //list of available medical appoitments for the selected period nad this doctor
            AvailableAppoitments = new ObservableCollection<MedicalAppointmentDTO>();
            AvailableAppoitments.Add(new MedicalAppointmentDTO() { room = tempRoom, beginning = new DateTime(2020, 5, 10, 15, 0, 0), type = Model.MedicalAppointmentType.examination, end = new DateTime(2020, 5, 10, 15, 30, 0) });
            AvailableAppoitments.Add(new MedicalAppointmentDTO() { room = tempRoom, beginning = new DateTime(2020, 5, 11, 15, 0, 0), type = Model.MedicalAppointmentType.examination, end = new DateTime(2020, 5, 11, 15, 30, 0) });
            AvailableAppoitments.Add(new MedicalAppointmentDTO() { room = tempRoom, beginning = new DateTime(2020, 5, 12, 15, 0, 0), type = Model.MedicalAppointmentType.examination, end = new DateTime(2020, 5, 12, 15, 30, 0) });
            AvailableAppoitments.Add(new MedicalAppointmentDTO() { room = tempRoom, beginning = new DateTime(2020, 5, 13, 15, 0, 0), type = Model.MedicalAppointmentType.examination, end = new DateTime(2020, 5, 13, 15, 30, 0) });
            AvailableAppoitments.Add(new MedicalAppointmentDTO() { room = tempRoom, beginning = new DateTime(2020, 5, 14, 15, 0, 0), type = Model.MedicalAppointmentType.examination, end = new DateTime(2020, 5, 14, 15, 30, 0) });
        }


    }






    public class PatientIDMatchConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.Equals(parameter))
            {
                return true;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return false;
        }
    }
}
