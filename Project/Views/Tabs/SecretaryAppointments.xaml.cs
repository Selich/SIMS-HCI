using Project.Model;
using Project.Views.Secretary;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project.Views.Tabs
{
    /// <summary>
    /// Interaction logic for SecretaryAppointments.xaml
    /// </summary>
    public partial class SecretaryAppointments : UserControl
    {
        public DateTime SelectedDate;
        public DateTime StartOfTheWeek;
        public DateTime EndOfTheWeek;
        public DateTime CurrentDate;
        public DoctorSearchModal DoctorModal;
        public SecretaryAppointments()
        {
            DoctorModal = new DoctorSearchModal(this);
            CurrentDate    = DateTime.Today;
            StartOfTheWeek = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            EndOfTheWeek   = StartOfTheWeek.AddDays(6);
            SelectedDate   = CurrentDate;
            InitializeComponent();

            startWeekLabel.Content  = StartOfTheWeek.ToString("dddd, dd MMMM yyyy");
            endWeekLabel.Content    = EndOfTheWeek.ToString("dddd, dd MMMM yyyy");
            currentDayLabel.Content = CurrentDate.ToString("dddd, dd MMMM yyyy");
        }
        private void Search_Doctor(object sender, RoutedEventArgs e) => DoctorModal.Show();
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
        private void Prev_Day_Click(object sender, RoutedEventArgs e)
        {
            CurrentDate.AddDays(-1);
            currentDayLabel.Content = CurrentDate.ToString("dddd, dd MMMM yyyy");
            CollectionViewSource.GetDefaultView(currentDayLabel.Content).Refresh();

        }

        private void Next_Day_Click(object sender, RoutedEventArgs e)
        {
            CurrentDate.AddDays(1);
            currentDayLabel.Content = CurrentDate.ToString("dddd, dd MMMM yyyy");
            CollectionViewSource.GetDefaultView(currentDayLabel.Content).Refresh();
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            drLabel.Content = null;

        }
        private void Prev_Week_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Next_Week_Click(object sender, RoutedEventArgs e)
        {

        }
        public List<List<TimeInterval>> GenerateTerms()
        {
            List<List<TimeInterval>> lsts = new List<List<TimeInterval>>();
            DateTime iterDay = StartOfTheWeek;
            
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
        private void Feedback_Click(object sender, RoutedEventArgs e)
        {
            var s = new FeedbackModal();
            s.Show();

        }
    }
}
