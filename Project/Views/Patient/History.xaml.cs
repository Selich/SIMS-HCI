using Project.Entity;
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
    /// Interaction logic for History.xaml
    /// </summary>
    public partial class History : Window
    {
        public DoctorDTO SelectedDoctor { get; set; }
        public AnamnezaDTO SelectedAnamneza { get; set; }
        public ObservableCollection<MedicalAppointmentDTO> PastAppoitments
        {
            get;
            set;
        }

        public History()
        {
            InitializeComponent();
            this.DataContext = this;

            RoomDTO tempRoom = new RoomDTO() { floor = "two", type = Model.RoomType.hospitalRoom};
            ReviewDTO tempReview = new ReviewDTO() { rating = 4 };
            AnamnezaDTO tempAnamneza = new AnamnezaDTO() { Description = "Lorem ipsum dolor sit amet," +
                " consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." +
                " Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." +
                " Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur" +
                " sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", Name = "Check up", Type = "Examination"
            };
            List<AnamnezaDTO> tempAnamnezas = new List<AnamnezaDTO>();
            tempAnamnezas.Add(tempAnamneza);
            DoctorDTO tempDoctor = new DoctorDTO() { FirstName = "Filip", LastName = "Zdelar", AvrageReviewScore = 4.5F };
            List<DoctorDTO> tempDoctors = new List<DoctorDTO>();
            tempDoctors.Add(tempDoctor);

            PastAppoitments = new ObservableCollection<MedicalAppointmentDTO>();
            PastAppoitments.Add(new MedicalAppointmentDTO() { room = tempRoom, beginning = new DateTime(2020, 5, 1, 15, 0, 0), type = Model.MedicalAppointmentType.examination, end = new DateTime(2020, 5, 1, 15, 30, 0), Doctors = tempDoctors, anamneza = tempAnamnezas , review = tempReview });
            PastAppoitments.Add(new MedicalAppointmentDTO() { room = tempRoom, beginning = new DateTime(2020, 5, 2, 18, 0, 0), type = Model.MedicalAppointmentType.examination, end = new DateTime(2020, 5, 2, 18, 30, 0), Doctors = tempDoctors , review = new ReviewDTO() { rating = 4 } });
            PastAppoitments.Add(new MedicalAppointmentDTO() { room = tempRoom, beginning = new DateTime(2020, 5, 3, 15, 0, 0), type = Model.MedicalAppointmentType.examination, end = new DateTime(2020, 5, 3, 15, 30, 0), Doctors = tempDoctors , review = new ReviewDTO() { rating = 5 } });
            PastAppoitments.Add(new MedicalAppointmentDTO() { room = tempRoom, beginning = new DateTime(2020, 5, 4, 15, 0, 0), type = Model.MedicalAppointmentType.examination, end = new DateTime(2020, 5, 4, 15, 30, 0), Doctors = tempDoctors , review = new ReviewDTO() { rating = 5 } });
            PastAppoitments.Add(new MedicalAppointmentDTO() { room = tempRoom, beginning = new DateTime(2020, 5, 5, 11, 0, 0), type = Model.MedicalAppointmentType.operation, end = new DateTime(2020, 5, 5, 11, 30, 0), Doctors = tempDoctors , review = new ReviewDTO() { rating = 3 } });
            PastAppoitments.Add(new MedicalAppointmentDTO() { room = tempRoom, beginning = new DateTime(2020, 5, 7, 14, 0, 0), type = Model.MedicalAppointmentType.operation, end = new DateTime(2020, 5, 7, 14, 30, 0), Doctors = tempDoctors , review = new ReviewDTO() { rating = 5 } });

            // need to add onSelect methods
            SelectedDoctor = tempDoctor;
            SelectedAnamneza = tempAnamneza;
        }
    }
}
