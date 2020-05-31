using Project.Views.Model;
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
        public AnamnesisDTO SelectedAnamneza { get; set; }
        public ObservableCollection<MedicalAppointmentDTO> PastAppoitments
        {
            get;
            set;
        }

        public History()
        {
            InitializeComponent();
            this.DataContext = this;

            RoomDTO tempRoom = new RoomDTO() { Floor = "two", Type = Project.Model.RoomType.hospitalRoom};
            ReviewDTO tempReview = new ReviewDTO() { Rating = 4 };
            AnamnesisDTO tempAnamneza = new AnamnesisDTO()
            {
                Description = "Lorem ipsum dolor sit amet," +
                " consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." +
                " Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." +
                " Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur" +
                " sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", Name = "Check up", Type = "Examination"
            };
            List<AnamnesisDTO> tempAnamnezas = new List<AnamnesisDTO> { tempAnamneza };
            DoctorDTO tempDoctor = new DoctorDTO() { FirstName = "Filip", LastName = "Zdelar", AverageReviewScore = 4.5F };
            List<DoctorDTO> tempDoctors = new List<DoctorDTO> { tempDoctor };

            PastAppoitments = new ObservableCollection<MedicalAppointmentDTO>();
            PastAppoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 1, 15, 0, 0), Type = Project.Model.MedicalAppointmentType.examination, End = new DateTime(2020, 5, 1, 15, 30, 0), Doctors = tempDoctors, Review = tempReview });
            PastAppoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 2, 18, 0, 0), Type = Project.Model.MedicalAppointmentType.examination, End = new DateTime(2020, 5, 2, 18, 30, 0), Doctors = tempDoctors , Review = new ReviewDTO() { Rating = 4 } });
            PastAppoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 3, 15, 0, 0), Type = Project.Model.MedicalAppointmentType.examination, End = new DateTime(2020, 5, 3, 15, 30, 0), Doctors = tempDoctors , Review = new ReviewDTO() { Rating = 5 } });
            PastAppoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 4, 15, 0, 0), Type = Project.Model.MedicalAppointmentType.examination, End = new DateTime(2020, 5, 4, 15, 30, 0), Doctors = tempDoctors , Review = new ReviewDTO() { Rating = 5 } });
            PastAppoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 5, 11, 0, 0), Type = Project.Model.MedicalAppointmentType.operation, End = new DateTime(2020, 5, 5, 11, 30, 0), Doctors = tempDoctors , Review = new ReviewDTO() { Rating = 3 } });
            PastAppoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 7, 14, 0, 0), Type = Project.Model.MedicalAppointmentType.operation, End = new DateTime(2020, 5, 7, 14, 30, 0), Doctors = tempDoctors , Review = new ReviewDTO() { Rating = 5 } });

            // need to add onSelect methods
            SelectedDoctor = tempDoctor;
            SelectedAnamneza = tempAnamneza;
        }
    }
}
