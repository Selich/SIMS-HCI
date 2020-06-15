using Project.Model;
using Project.Views.Model;
using Project.Views.Secretary;
using Project.Views.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
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
    public partial class SecretaryAppointments : System.Windows.Controls.UserControl
    {
        App app;
        public DateTime CurrentDate { get; set; }
        public SecretaryAppointments()
        {
            InitializeComponent();
            app = System.Windows.Application.Current as App;
            CurrentDoctor.Content = app.SelectedDoctor;
            nextAppointment.Content = app.MedicalAppointments[0];
            AppointmentList.ItemsSource = app.MedicalAppointments;




            ListDate.Content = app.SelectedDate.ToShortDateString();
            CurrentDate = app.SelectedDate;

            //ListDate.Content =
            //    app.SelectedDate.StartOfWeek(DayOfWeek.Monday).ToShortDateString() +
            //    ":" +
            //    app.SelectedDate.StartOfWeek(DayOfWeek.Sunday).ToShortDateString();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(AppointmentList.ItemsSource);
            view.Filter = CombinedFilter;


        }
        private bool CombinedFilter(object item)
            => DoctorFilter(item) && DateFilter(item);
        private bool DoctorFilter(object item)
          => (app.SelectedDoctor == null) ||
            (item as MedicalAppointmentDTO).Doctors.Contains(app.SelectedDoctor);
        private bool DateFilter(object item)
          => (item as MedicalAppointmentDTO).Beginning.ToShortDateString().Equals(CurrentDate.ToShortDateString());

        private void Search_Doctor(object sender, RoutedEventArgs e) => new DoctorSearchModal(this).Show();
        private void Feedback_Click(object sender, RoutedEventArgs e) => new FeedbackModal().Show();
        private void Settings_Click(object sender, RoutedEventArgs e) => new SettingsModal().Show();
        private void Demo_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click(object sender, RoutedEventArgs e) => new SecretaryCreateModal().Show();
        private void GenerateReportButton_Click(object sender, RoutedEventArgs e) => new SecretaryGenerateReport().Show();

        private void AppointmentList_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }

        private void CurrentDoctor_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
            => CollectionViewSource.GetDefaultView(AppointmentList.ItemsSource).Refresh();

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            DoctorGrid.Visibility = Visibility.Hidden;
            CurrentDoctor.Content = "";
            CollectionViewSource.GetDefaultView(AppointmentList.ItemsSource).Refresh();

        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentDate.AddDays(-1);
            CollectionViewSource.GetDefaultView(AppointmentList.ItemsSource).Refresh();
            ListDate.Content = CurrentDate.ToShortDateString();
            CollectionViewSource.GetDefaultView(ListDate.Content).Refresh();

        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentDate.AddDays(1);
            CollectionViewSource.GetDefaultView(AppointmentList.ItemsSource).Refresh();
            ListDate.Content = CurrentDate.ToShortDateString();
            CollectionViewSource.GetDefaultView(ListDate.Content).Refresh();

        }
    }
}
