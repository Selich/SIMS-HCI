using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Model;
using Project.ItemGenerators;
using Project.Repositories;

namespace Project.Views.Secretary
{
        public static class DateTimeExtensions
        {
            public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
            {
                int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
                return dt.AddDays(-1 * diff).Date;
            }
        }
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public List<TimeInterval> listOfTerms;
        public  Model.Doctor selectedDoctor { get; set; }
        public string drName { get; set; }
        public Model.Secretary user;
        public List<MedicalAppointment> medicalAppointments;
        public DoctorSearchModal doctorModal;
        public MedicalAppointment selectedAppointment;
        public Question selectedQuestion;
        public DateTime selectedDate;
        public HomeWindow()
        {
            DateTime currentDate = DateTime.Now;
            DateTime selectedDate = currentDate;
            user = new Model.Secretary();
            user.firstName = "Nikola";
            user.lastName = "Selic";
            user.address = new Address("7a", "Bulevar deposta Stefana", "Novi Sad", "Republika Srbija", "21000");
            user.email = "n_selic@uns.ac.rs";



            doctorModal = new DoctorSearchModal(this);
            PatientRepository pr = new PatientRepository();
            DoctorRepository dr = new DoctorRepository();
            QuestionRepository qr = new QuestionRepository();
            Generators gen = new Generators();

            InitializeComponent();

            dateTimePicker.SelectedDate = DateTime.Today;

            medicalAppointments = gen.GetMedicalAppointments(10);
            var weeksAppointments = GetThisWeeksAppointements(medicalAppointments);

            listPatients.ItemsSource = pr.ReadCSV("../../Data/patients.csv");
            listPatientsCreate.ItemsSource = pr.ReadCSV("../../Data/patients.csv");

            listQuestions.ItemsSource = qr.ReadCSV("../../Data/questions.csv");
            listTerm.ItemsSource = medicalAppointments;
            listAppointments.ItemsSource = medicalAppointments;
            nextAppointment.Content = medicalAppointments[0];

            listRoom.ItemsSource = gen.GetRooms(10);


            lst.ItemsSource = GenerateTerms();


            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listPatients.ItemsSource);
            CollectionView viewCreate = (CollectionView)CollectionViewSource.GetDefaultView(listPatientsCreate.ItemsSource);
            CollectionView viewRooms = (CollectionView)CollectionViewSource.GetDefaultView(listRoom.ItemsSource);

            view.Filter = UserFilter;
            viewCreate.Filter = UserFilterCreate;
            viewRooms.Filter = RoomFilter;

        }
        public List<List<TimeInterval>> GenerateTerms()
        {
            List<List<TimeInterval>> lsts = new List<List<TimeInterval>>();
            DateTime startOfTheWeek = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            DateTime iterDay = startOfTheWeek;
            
            for (int i = 0; i < 7; i++)
            {
                lsts.Add(new List<TimeInterval>());
                for (int j = 0; j < 7; j++)
                {
                    lsts[i].Add(new TimeInterval(iterDay, iterDay.AddDays(1)));
                    iterDay.AddDays(1);
                }
            }
            return lsts;
        }

        public List<MedicalAppointment> GetThisWeeksAppointements(List<MedicalAppointment> appointments)
        {
            //10080
            List<MedicalAppointment> list = new List<MedicalAppointment>();
            DateTime startOfTheWeek = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            DateTime endOfTheWeek = startOfTheWeek.AddDays(7);

            TimeSpan weekInterval = startOfTheWeek - endOfTheWeek;

            foreach(MedicalAppointment item in appointments)
            {
                if(startOfTheWeek <= item.beginning  && item.end <= endOfTheWeek)
                {
                    list.Add(item);
                }
            }

            return list;


        }
        public void handleWeekCalendar(List<MedicalAppointment> list)
        {
            //var weekDg = new System.Windows.Controls.DataGrid();
            //this.weekGrid.Children.Add(weekDg);
            //for(int i = 1; i <= 4; ++i)
            //{
            //    var col = new DataGridTextColumn();
            //    col.Header = "id";
            //    col.Binding = new System.Windows.Data.Binding("id");
            //    weekDg.Columns.Add(col);
            //}

            //foreach(var item in list)
            //{
            //    weekDg.Items.Add(item);

            //}

        }
        
        private void Term_Click(object sender, RoutedEventArgs e)
        {
            MedicalAppointment item = (MedicalAppointment)(sender as System.Windows.Controls.Button).DataContext;
            var s = new AppointmentModal(item);
            s.Show();

        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(patientFilter.Text))
                return true;
            else
                return ((item as User).firstName.IndexOf(patientFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private bool UserFilterCreate(object item)
        {
            if (String.IsNullOrEmpty(patientFilterCreate.Text))
                return true;
            else
                return ((item as User).firstName.IndexOf(patientFilterCreate.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private bool RoomFilter(object item)
        {
            if (String.IsNullOrEmpty(roomFilter.Text))
                return true;
            else
                return ((item as Room).id.ToString().IndexOf(roomFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
                //return ((item as Room).id.ToString().IndexOf(roomFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0 && (item as Room).type.ToString().IndexOf(appointmentType.SelectedItem.ToString(), StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(listPatients.ItemsSource).Refresh();
        }
        private void roomFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(listRoom.ItemsSource).Refresh();
        }
        private void txtFilterCreate_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(listPatientsCreate.ItemsSource).Refresh();
        }

        private void Search_Doctor(object sender, RoutedEventArgs e)
        {
            doctorModal.Show();

        }
        private bool DateFilter(object item)
        {
            return true;
            //if (String.IsNullOrEmpty(datePicker.SelectedDate.Value))
            //    return true;
            //else
            //    return ((item as User).firstName.IndexOf(patientFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private void dpick_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedDate = dateTimePicker.SelectedDate.Value;
            //CollectionViewSource.GetDefaultView(listTerm.ItemsSource).Refresh();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            List_Patients_Create.Visibility = Visibility.Hidden;
            Guest_Button.Visibility = Visibility.Hidden;
            Guest_Account_Create.Visibility = Visibility.Visible;
            Cancel_Button.Visibility = Visibility.Visible;
        }
        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            List_Patients_Create.Visibility = Visibility.Visible;
            Guest_Button.Visibility = Visibility.Visible;
            Guest_Account_Create.Visibility = Visibility.Hidden;
            Cancel_Button.Visibility = Visibility.Hidden;
        }
        public void refreshContent()
        {
            MedicalAppointmentRepository mr = new MedicalAppointmentRepository();
            string id = ((System.Windows.Controls.Label)this.FindName("drId")).Content.ToString();
            mr = new MedicalAppointmentRepository();
            medicalAppointments = mr.GetMedicalAppointmentsByDoctorId(Int32.Parse(id));
            System.Windows.MessageBox.Show(medicalAppointments.ToString(),"test", MessageBoxButton.OK);

        }
        private void questionsList_KeyDown(object sender, KeyboardEventArgs e)
        {
            selectedQuestion = (Question)listQuestions.SelectedItem;
            var modal = new QuestionModal(selectedQuestion);
            modal.Show();


        }

        private void Feedback_Click(object sender, RoutedEventArgs e)
        {
            var s = new FeedbackModal();
            s.Show();

        }
    }
}
