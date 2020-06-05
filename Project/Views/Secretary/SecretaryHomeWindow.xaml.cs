using Project.Model;
using Project.Views.Commands;
using Project.Views.Model;
using Project.Views.Tabs;
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
using System.Windows.Shapes;

namespace Project.Views.Secretary
{
    /// <summary>
    /// Interaction logic for SecretaryHomeWindow.xaml
    /// </summary>
    public partial class SecretaryHomeWindow : Window
    {
        public MedicalAppointmentDTO SelectedAppointment;

        public SecretaryHomeWindow()
        {


            SecretaryAppointments appointmentsView = new SecretaryAppointments();

            InitializeComponent();

            DataContext = new DataContext();


        //CollectionView viewAdress = (CollectionView)CollectionViewSource.GetDefaultView(listPatients.ItemsSource);
        //CollectionView viewNumber = (CollectionView)CollectionViewSource.GetDefaultView(listPatients.ItemsSource);
        //CollectionView view       = (CollectionView)CollectionViewSource.GetDefaultView(listPatients.ItemsSource);
        //CollectionView viewCreate = (CollectionView)CollectionViewSource.GetDefaultView(listPatientsCreate.ItemsSource);
        //CollectionView viewRooms  = (CollectionView)CollectionViewSource.GetDefaultView(listRoom.ItemsSource);

        //view.Filter = UserFilter;
        //viewCreate.Filter = UserFilterCreate;
        //viewRooms.Filter = RoomFilter;

    }

        public void ViewHelp()
        {

        }
        
        private void Term_Click(object sender, RoutedEventArgs e)
        {
            MedicalAppointment item = (MedicalAppointment)(sender as System.Windows.Controls.Button).DataContext;
            var s = new AppointmentModal(item);
            s.Show();

        }
        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            GuestDTO item = (GuestDTO)(sender as System.Windows.Controls.Button).DataContext;
            var s = new ProfileModal(item);
            s.Show();

        }
        private void ShowShortcuts(object sender, RoutedEventArgs e)
        {
            var s = new ShortcutsModal();
            s.Show();

        }

        //private bool UserFilter(object item)
        //{
        //    if (String.IsNullOrEmpty(patientFilter.Text))
        //        return true;
        //    else
        //        return ((item as User).FirstName.IndexOf(patientFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        //}
        //private bool UserFilterCreate(object item)
        //{
        //    if (String.IsNullOrEmpty(patientFilterCreate.Text))
        //        return true;
        //    else
        //        return ((item as User).FirstName.IndexOf(patientFilterCreate.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        //}
        //private bool RoomFilter(object item)
        //{
        //    if (String.IsNullOrEmpty(roomFilter.Text))
        //        return true;
        //    else
        //        return ((item as Room).id.ToString().IndexOf(roomFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        //        //return ((item as Room).id.ToString().IndexOf(roomFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0 && (item as Room).type.ToString().IndexOf(appointmentType.SelectedItem.ToString(), StringComparison.OrdinalIgnoreCase) >= 0);
        //}

        private bool DateFilter(object item)
        {
            return true;
            //if (String.IsNullOrEmpty(datePicker.SelectedDate.Value))
            //    return true;
            //else
            //    return ((item as User).firstName.IndexOf(patientFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        public void refreshContent()
        {
            ////MedicalAppointmentRepository mr = new MedicalAppointmentRepository();
            //string id = ((System.Windows.Controls.Label)this.FindName("drId")).Content.ToString();
            //mr = new MedicalAppointmentRepository();
            //medicalAppointments = mr.GetMedicalAppointmentsByDoctorId(Int32.Parse(id));
            //System.Windows.MessageBox.Show(medicalAppointments.ToString(),"test", MessageBoxButton.OK);

        }







    }
    }
