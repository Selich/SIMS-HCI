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
            InitializeComponent();

        }
        private void Search_Doctor(object sender, RoutedEventArgs e) => DoctorModal.Show();
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            drLabel.Content = null;

        }
        private void Feedback_Click(object sender, RoutedEventArgs e)
        {
            var s = new FeedbackModal();
            s.Show();

        }
    }
}
