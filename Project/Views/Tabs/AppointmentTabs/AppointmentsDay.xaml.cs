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

namespace Project.Views.Tabs.AppointmentTabs
{
    /// <summary>
    /// Interaction logic for AppointmentsDay.xaml
    /// </summary>
    public partial class AppointmentsDay : UserControl
    {
        public DateTime SelectedDate;
        public DateTime StartOfTheWeek;
        public DateTime EndOfTheWeek;
        public DateTime CurrentDate;
        public AppointmentsDay()
        {
            CurrentDate    = DateTime.Today;
            StartOfTheWeek = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            EndOfTheWeek   = StartOfTheWeek.AddDays(6);
            SelectedDate   = CurrentDate;
            InitializeComponent();

            currentDayLabel.Content = CurrentDate.ToString("dddd, dd MMMM yyyy");
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
    }
}
