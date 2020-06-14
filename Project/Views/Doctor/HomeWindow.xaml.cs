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
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using Project.Views.Model;
using System.Collections.ObjectModel;
using Project.Model;

namespace Project.Views.Doctor
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public ObservableCollection<MedicalAppointmentDTO> Appoitments { get; set; }
        public ObservableCollection<MedicalAppointmentDTO> PastAppoitments { get; set; }
        public ObservableCollection<MedicalAppointmentDTO> AvailableAppoitments { get; set; }

        public DoctorDTO LoggedInDoctor { get; set; }
        public PatientDTO LoggedInPatient { get; set; }

        public String TartgetRosource { get; set; }
        public List<String> ListOfRosourceses { get; set; }

        public HomeWindow()
        {

            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();

            this.DataContext = this;
            HideTextBoxes();
            HidePlaceHolders();
            HideResource();

            saveEdit.Visibility = Visibility.Collapsed;
            cancleEdit.Visibility = Visibility.Collapsed;

            // Doctor
            AddressDTO tempAddress = new AddressDTO() { City = "Novi Sad", Country = "Serbia", Number = "25", PostCode = "21000", Street = "Laze Kostica 14" };
            LoggedInDoctor = new DoctorDTO() { FirstName = "Predrag", LastName = "Kon", DateOfBirth = new DateTime(1998, 8, 25), Email = "pred12@gmail.com", Gender = "Muski", Jmbg = "0234567890111", TelephoneNumber = "06551232123", Address = tempAddress, MedicalRole= "Specijalista" };

            LoggedInPatient = new PatientDTO() { FirstName = "Uros", LastName = "Milovanovic", DateOfBirth = new DateTime(1998, 8, 25), Email = "urke123@gmail.com", Gender = "Muški", InsurenceNumber = "1234567", Jmbg = "1234567890", TelephoneNumber = "06551232123", Address = tempAddress};


            //Current Appoitments
            RoomDTO tempRoom = new RoomDTO() { Floor = "One", Id = 4, Ward = "Check" };
            Appoitments = new ObservableCollection<Model.MedicalAppointmentDTO>();
            Appoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 10, 15, 0, 0), Type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 10, 15, 30, 0), IsScheduled = true });
            Appoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 11, 18, 0, 0), Type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 11, 18, 30, 0), IsScheduled = true });
            Appoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 12, 15, 0, 0), Type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 12, 15, 30, 0), IsScheduled = true });
            Appoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 13, 15, 0, 0), Type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 13, 15, 30, 0), IsScheduled = true });
            Appoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 14, 11, 0, 0), Type = MedicalAppointmentType.operation, End = new DateTime(2020, 5, 14, 11, 30, 0), IsScheduled = true });
            Appoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 15, 14, 0, 0), Type = MedicalAppointmentType.operation, End = new DateTime(2020, 5, 15, 14, 30, 0), IsScheduled = true });


            //History
            DoctorDTO tempDoctor = new DoctorDTO() { FirstName = "Filip Zdelar" };
            ReviewDTO tempReview = new ReviewDTO(5, "yes");
            List<DoctorDTO> tempDoctors = new List<DoctorDTO>();
            tempDoctors.Add(tempDoctor);
            PastAppoitments = new ObservableCollection<Model.MedicalAppointmentDTO>();
            PastAppoitments.Add(new MedicalAppointmentDTO() { Id = 0, Room = tempRoom, Beginning = new DateTime(2020, 5, 10, 15, 0, 0), Type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 10, 15, 30, 0), Doctors = tempDoctors, Review = tempReview });
            PastAppoitments.Add(new MedicalAppointmentDTO() { Id = 1, Room = tempRoom, Beginning = new DateTime(2020, 5, 11, 18, 0, 0), Type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 11, 18, 30, 0), Doctors = tempDoctors, Review = tempReview });
            PastAppoitments.Add(new MedicalAppointmentDTO() { Id = 2, Room = tempRoom, Beginning = new DateTime(2020, 5, 12, 15, 0, 0), Type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 12, 15, 30, 0), Doctors = tempDoctors, Review = tempReview });
            PastAppoitments.Add(new MedicalAppointmentDTO() { Id = 3, Room = tempRoom, Beginning = new DateTime(2020, 5, 13, 15, 0, 0), Type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 13, 15, 30, 0), Doctors = tempDoctors, Review = tempReview });
            PastAppoitments.Add(new MedicalAppointmentDTO() { Id = 4, Room = tempRoom, Beginning = new DateTime(2020, 5, 14, 11, 0, 0), Type = MedicalAppointmentType.operation, End = new DateTime(2020, 5, 14, 11, 30, 0), Doctors = tempDoctors, Review = tempReview });
            PastAppoitments.Add(new MedicalAppointmentDTO() { Id = 5, Room = tempRoom, Beginning = new DateTime(2020, 5, 15, 14, 0, 0), Type = MedicalAppointmentType.operation, End = new DateTime(2020, 5, 15, 14, 30, 0), Doctors = tempDoctors, Review = tempReview });


            AvailableAppoitments = new ObservableCollection<Model.MedicalAppointmentDTO>();

            ListOfRosourceses = new List<string>();
            TartgetRosource = "";
        }

        private void HideTextBoxes()
        {
            textbox1.Visibility = Visibility.Collapsed;
            textbox2.Visibility = Visibility.Collapsed;
            textbox3.Visibility = Visibility.Collapsed;
            textbox4.Visibility = Visibility.Collapsed;
            textbox5.Visibility = Visibility.Collapsed;
            textbox6.Visibility = Visibility.Collapsed;
            textbox7.Visibility = Visibility.Collapsed;
            textbox8.Visibility = Visibility.Collapsed;
            textbox9.Visibility = Visibility.Collapsed;
        }

        private void HidePlaceHolders()
        {
            textbox1p.Visibility = Visibility.Collapsed;
            textbox2p.Visibility = Visibility.Collapsed;
            textbox3p.Visibility = Visibility.Collapsed;
            textbox4p.Visibility = Visibility.Collapsed;
            textbox5p.Visibility = Visibility.Collapsed;
            textbox6p.Visibility = Visibility.Collapsed;
            textbox7p.Visibility = Visibility.Collapsed;
            textbox8p.Visibility = Visibility.Collapsed;
            textbox9p.Visibility = Visibility.Collapsed;
        }
        
        private void ChangeMode_Click(object sender, RoutedEventArgs e)
        {
            label0.Visibility = Visibility.Collapsed;
            label1.Visibility = Visibility.Collapsed;
            label2.Visibility = Visibility.Collapsed;
            label3.Visibility = Visibility.Collapsed;
            label4.Visibility = Visibility.Collapsed;
            label5.Visibility = Visibility.Collapsed;
            label6.Visibility = Visibility.Collapsed;
            label7.Visibility = Visibility.Collapsed;
            label8.Visibility = Visibility.Collapsed;

            ShowPlaceHolders();

            //SetPlaceHoldersAsLabels();

            saveEdit.Visibility = Visibility.Visible;

            cancleEdit.Visibility = Visibility.Visible;
            buttonEdit.Visibility = Visibility.Collapsed;
            //_isEditMod = false;
        }

        private void SetPlaceHoldersAsLabels()
        {
            textbox1p.Text = label0.Text;
            textbox2p.Text = label1.Text;
            //textbox3p.Text = label2.Text;
            textbox4p.Text = label6.Text;
            textbox5p.Text = label7.Text;
            textbox6p.Text = label8.Text;
            textbox7p.Text = label3.Text;
            textbox8p.Text = label4.Text;
            textbox9p.Text = label5.Text;
        }

        private void ShowPlaceHolders()
        {
            textbox1p.Visibility = Visibility.Visible;
            textbox2p.Visibility = Visibility.Visible;
            textbox3p.Visibility = Visibility.Visible;
            textbox4p.Visibility = Visibility.Visible;
            textbox5p.Visibility = Visibility.Visible;
            textbox6p.Visibility = Visibility.Visible;
            textbox7p.Visibility = Visibility.Visible;
            textbox8p.Visibility = Visibility.Visible;
            textbox9p.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveEdit_Click(object sender, RoutedEventArgs e)
        {
            var alert = new Doctor.Alert();
            alert.Show();
            label0.Visibility = Visibility.Visible;
            label1.Visibility = Visibility.Visible;
            label2.Visibility = Visibility.Visible;
            label3.Visibility = Visibility.Visible;
            label4.Visibility = Visibility.Visible;
            label5.Visibility = Visibility.Visible;
            label6.Visibility = Visibility.Visible;
            label7.Visibility = Visibility.Visible;
            label8.Visibility = Visibility.Visible;
            /*
            textbox1.Visibility = Visibility.Collapsed;
            textbox2.Visibility = Visibility.Collapsed;
            textbox3.Visibility = Visibility.Collapsed;
            textbox4.Visibility = Visibility.Collapsed;
            textbox5.Visibility = Visibility.Collapsed;
            textbox6.Visibility = Visibility.Collapsed;
            textbox7.Visibility = Visibility.Collapsed;
            textbox8.Visibility = Visibility.Collapsed;
            textbox9.Visibility = Visibility.Collapsed;*/


            HidePlaceHolders();
            HideTextBoxes();

            saveEdit.Visibility = Visibility.Collapsed;
            cancleEdit.Visibility = Visibility.Collapsed;
            buttonEdit.Visibility = Visibility.Visible;
        }

        private void CancleInfo_Click(object sender, RoutedEventArgs e)
        {
            label0.Visibility = Visibility.Visible;
            label1.Visibility = Visibility.Visible;
            label2.Visibility = Visibility.Visible;
            label3.Visibility = Visibility.Visible;
            label4.Visibility = Visibility.Visible;
            label5.Visibility = Visibility.Visible;
            label6.Visibility = Visibility.Visible;
            label7.Visibility = Visibility.Visible;
            label8.Visibility = Visibility.Visible;
            HideTextBoxes();
            HidePlaceHolders();
            saveEdit.Visibility = Visibility.Collapsed;
            cancleEdit.Visibility = Visibility.Collapsed;
            buttonEdit.Visibility = Visibility.Visible;
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            var s = new Doctor.HistoryPatient();
            s.Show();
        }
        
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /*
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }*/

        private void Alert_Click(object sender, RoutedEventArgs e)
        {
            var alert = new Doctor.Alert();
            alert.Show();
        }

        private void Wizard_Click(object sender, RoutedEventArgs e)
        {
        }
        

        private void Textbox1p_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textbox1.Text = textbox1p.Text;
            textbox1.Visibility = Visibility.Visible;
            textbox1p.Visibility = Visibility.Collapsed;
            Keyboard.Focus(textbox1);
        }
        private void Textbox2p_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textbox2.Text = textbox2p.Text;
            textbox2.Visibility = Visibility.Visible;
            textbox2p.Visibility = Visibility.Collapsed;
            Keyboard.Focus(textbox2);
        }
        private void Textbox3p_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textbox3.Text = textbox3p.Text;
            textbox3.Visibility = Visibility.Visible;
            textbox3p.Visibility = Visibility.Collapsed;
            Keyboard.Focus(textbox3);
        }
        private void Textbox4p_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textbox4.Text = textbox4p.Text;
            textbox4.Visibility = Visibility.Visible;
            textbox4p.Visibility = Visibility.Collapsed;
            Keyboard.Focus(textbox4);
        }
        private void Textbox5p_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textbox5.Text = textbox5p.Text;
            textbox5.Visibility = Visibility.Visible;
            textbox5p.Visibility = Visibility.Collapsed;
            Keyboard.Focus(textbox5);
        }
        private void Textbox6p_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textbox6.Text = textbox6p.Text;
            textbox6.Visibility = Visibility.Visible;
            textbox6p.Visibility = Visibility.Collapsed;
            Keyboard.Focus(textbox6);
        }
        private void Textbox7p_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textbox7.Text = textbox7p.Text;
            textbox7.Visibility = Visibility.Visible;
            textbox7p.Visibility = Visibility.Collapsed;
            Keyboard.Focus(textbox7);

        }
        private void Textbox8p_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textbox8.Text = textbox8p.Text;
            textbox8.Visibility = Visibility.Visible;
            textbox8p.Visibility = Visibility.Collapsed;
            Keyboard.Focus(textbox8);
        }
        private void Textbox9p_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textbox9.Text = textbox9p.Text;
            textbox9.Visibility = Visibility.Visible;
            textbox9p.Visibility = Visibility.Collapsed;
            Keyboard.Focus(textbox9);
        }

        private void DeleteElementList(object sender, RoutedEventArgs e)
        {
            //((ListBoxItem)((StackPanel)(((Button)sender).Parent)).Parent).Visibility = Visibility.Collapsed;
            //((ListBoxItem)((DataTemplate)((StackPanel)(((Button)sender).Parent)).Parent).Parent).Visibility = Visibility.Collapsed;
        }

        private void ComboBoxItem_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {
            TartgetRosource = ComboBox12_Copy4.SelectedValue.ToString();
        }

        private void ComboBox12_Copy4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TartgetRosource = ComboBox12_Copy4.SelectedValue.ToString().Remove(0, 38);
            ResorurceText.Text = TartgetRosource;

            NumberTextBox_Copy1.Visibility = Visibility.Visible;
            NumberTextBox_Copy3.Visibility = Visibility.Visible;
            AmountO.Visibility = Visibility.Visible;
            PerdaysO.Visibility = Visibility.Visible;
            ResorurceText.Visibility = Visibility.Visible;
            AddResource.Visibility = Visibility.Visible;
        }

        private void AddResource_Click(object sender, RoutedEventArgs e)
        {
            HideResource();
            //ListOfRosourceses
            ListOfRosourcesesListOfResources.Items.Add(TartgetRosource);
            ListOfRosourceses.Add(TartgetRosource);
            //ListOfResources.ItemTemplate Items.Add(TartgetRosource);
        }

        private void HideResource()
        {
            NumberTextBox_Copy1.Visibility = Visibility.Collapsed;
            NumberTextBox_Copy3.Visibility = Visibility.Collapsed;
            AmountO.Visibility = Visibility.Collapsed;
            PerdaysO.Visibility = Visibility.Collapsed;
            ResorurceText.Visibility = Visibility.Collapsed;
            AddResource.Visibility = Visibility.Collapsed;
        }
    }
}
