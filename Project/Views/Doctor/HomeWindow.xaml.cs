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
        public ObservableCollection<MedicalAppointmentDTO> CurrentAppoitments { get; set; }

        public ObservableCollection<MedicalAppointmentDTO> Appoitments { get; set; }
        public ObservableCollection<MedicalAppointmentDTO> PastAppoitments { get; set; }
        public ObservableCollection<MedicalAppointmentDTO> AvailableAppoitments { get; set; }


        public DoctorDTO LoggedInDoctor { get; set; }
        public PatientDTO LoggedInPatient { get; set; }

        public String TartgetRosource { get; set; }
        public List<String> ListOfRosourceses { get; set; }
        public int obrisnni = 0;
        public DateTime SelectedDate { get; set; }
        public App app;
        public String Lek { get; set; }
        public int Amount { get; set; }
        public int Freq { get; set; }
        public String description { get; set; }

        public DateTime BeginApp { get; set; }
        public DateTime EndApp { get; set; }
        public String TypeOfTermin { get; set; }
        public String requiest {get;set;}
          

        public List<String> Recepies { get; set; }

        public HomeWindow()
        {

            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();

            app = Application.Current as App;
            InitializeComponent();

            PecepiesList.ItemsSource = app.PrescriptionController.GetAll();

            this.DataContext = this;
            HideTextBoxes();
            HidePlaceHolders();
            HideResource();

            saveEdit.Visibility = Visibility.Collapsed;
            cancleEdit.Visibility = Visibility.Collapsed;

            // Doctor
            AddressDTO tempAddress = new AddressDTO() { City = "Novi Sad", Country = "Serbia", Number = "25", PostCode = "21000", Street = "Laze Kostica" };
            LoggedInDoctor = new DoctorDTO() { FirstName = "Predrag", LastName = "Kon", DateOfBirth = new DateTime(1998, 8, 25), Email = "pred12@gmail.com", Gender = "Muski", Jmbg = "0234567890111", TelephoneNumber = "06551232123", Address = tempAddress, MedicalRole= "Specijalista" };

            LoggedInPatient = new PatientDTO() { FirstName = "Uros", LastName = "Milovanovic", DateOfBirth = new DateTime(1998, 8, 25), Email = "urke123@gmail.com", Gender = "Muski", InsurenceNumber = "1234567", Jmbg = "1234567890", TelephoneNumber = "06551232123", Address = tempAddress};


            //Current Appoitments
            RoomDTO tempRoom = new RoomDTO() { Floor = "One", Id = 4, Ward = "Check" };
            Appoitments = new ObservableCollection<Model.MedicalAppointmentDTO>();
            Appoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 15, 11, 0, 0), Type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 13, 15, 30, 0), IsScheduled = true });
            Appoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 15, 12, 0, 0), Type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 13, 18, 30, 0), IsScheduled = true });
            Appoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 14, 13, 0, 0), Type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 15, 15, 30, 0), IsScheduled = true });
            Appoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 13, 14, 0, 0), Type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 13, 15, 30, 0), IsScheduled = true });
            Appoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 14, 15, 0, 0), Type = MedicalAppointmentType.operation, End = new DateTime(2020, 5, 14, 1, 30, 0), IsScheduled = true });
            Appoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 15, 16, 0, 0), Type = MedicalAppointmentType.operation, End = new DateTime(2020, 5, 15, 5, 30, 0), IsScheduled = true });
            Appoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 10, 17, 0, 0), Type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 15, 5, 30, 0), IsScheduled = true });
            Appoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 11, 18, 0, 0), Type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 15, 18, 30, 0), IsScheduled = true });
            Appoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 12, 19, 0, 0), Type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 15, 15, 30, 0), IsScheduled = true });
            Appoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 13, 10, 0, 0), Type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 13, 15, 30, 0), IsScheduled = true });
            Appoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 14, 11, 0, 0), Type = MedicalAppointmentType.operation, End = new DateTime(2020, 5, 14, 15, 30, 0), IsScheduled = true });
            Appoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 15, 11, 0, 0), Type = MedicalAppointmentType.operation, End = new DateTime(2020, 5, 15, 14, 30, 0), IsScheduled = true });
            Appoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 25, 11, 0, 0), Type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 13, 15, 30, 0), IsScheduled = true });
            Appoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 25, 12, 0, 0), Type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 13, 18, 30, 0), IsScheduled = true });
            Appoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 24, 13, 0, 0), Type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 15, 15, 30, 0), IsScheduled = true });
            Appoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 23, 14, 0, 0), Type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 13, 15, 30, 0), IsScheduled = true });
            Appoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 24, 15, 0, 0), Type = MedicalAppointmentType.operation, End = new DateTime(2020, 5, 14, 1, 30, 0), IsScheduled = true });
            Appoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 25, 16, 0, 0), Type = MedicalAppointmentType.operation, End = new DateTime(2020, 5, 15, 5, 30, 0), IsScheduled = true });
            Appoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 20, 17, 0, 0), Type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 15, 5, 30, 0), IsScheduled = true });
            Appoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 21, 18, 0, 0), Type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 15, 18, 30, 0), IsScheduled = true });
            Appoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 22, 19, 0, 0), Type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 15, 15, 30, 0), IsScheduled = true });
            Appoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 23, 10, 0, 0), Type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 13, 15, 30, 0), IsScheduled = true });
            Appoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 24, 11, 0, 0), Type = MedicalAppointmentType.operation, End = new DateTime(2020, 5, 14, 15, 30, 0), IsScheduled = true });
            Appoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 25, 11, 0, 0), Type = MedicalAppointmentType.operation, End = new DateTime(2020, 5, 15, 14, 30, 0), IsScheduled = true });


            CurrentAppoitments = new ObservableCollection<MedicalAppointmentDTO>();

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
            obrisnni = 0;
            SelectedDate = new DateTime();
            app = Application.Current as App;
            Recepies = new List<string>();
            TypeOfTermin = "";
            Title.Text += " Predrag Kon";// + tempDoctor.FirstName + " " + tempDoctor.LastName;

            Medicine_toAdd.Visibility = Visibility.Hidden;
            NumberTextBox.Visibility = Visibility.Hidden;
            NumberTextBox_Copy.Visibility = Visibility.Hidden;
            Kol_med.Visibility = Visibility.Hidden;
            Uc_med.Visibility = Visibility.Hidden;
            AddMediciniToList.Visibility = Visibility.Hidden;

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
            

            saveEdit.Visibility = Visibility.Visible;

            cancleEdit.Visibility = Visibility.Visible;
            buttonEdit.Visibility = Visibility.Collapsed;
            //_isEditMod = false;
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
            var wiz = new WizardWindow();
            wiz.Show();
            //Close();
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
            //(((ListBox)((DataTemplate)((StackPanel)((Button)sender).Parent).Parent).Parent)).Visibility = Visibility.Collapsed;

            obrisnni++;
            ((StackPanel)((Button)sender).Parent).Visibility = Visibility.Collapsed;

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
            //NumberTextBox_Copy3.Visibility = Visibility.Visible;
            AmountO.Visibility = Visibility.Visible;
            //PerdaysO.Visibility = Visibility.Visible;
            ResorurceText.Visibility = Visibility.Visible;
            AddResource.Visibility = Visibility.Visible;
        }

        private void AddResource_Click(object sender, RoutedEventArgs e)
        {
            HideResource();
            //ListOfRosourceses
            string res = "";
            res += TartgetRosource;
            if (NumberTextBox_Copy1 != null && NumberTextBox_Copy1.Text != "")
            {
                res += " "+NumberTextBox_Copy1.Text;
                
            }

            ListOfRosourcesesListOfResources.Items.Add(res);
            ListOfRosourceses.Add(res);
            //ListOfResources.ItemTemplate Items.Add(TartgetRosource);

        }

        private void HideResource()
        {
            NumberTextBox_Copy1.Visibility = Visibility.Collapsed;
            //NumberTextBox_Copy3.Visibility = Visibility.Collapsed;
            AmountO.Visibility = Visibility.Collapsed;
            //PerdaysO.Visibility = Visibility.Collapsed;
            ResorurceText.Visibility = Visibility.Collapsed;
            AddResource.Visibility = Visibility.Collapsed;
        }

        private void CalendarChoose_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            SelecetedDate2.Content = SelectedDate.ToShortDateString();
            //CurrentAppoitments = new ObservableCollection<MedicalAppointmentDTO>();
            CurrentAppoitments.Clear();
            foreach (MedicalAppointmentDTO termin in Appoitments)
            {
                if(termin.Beginning.CompareTo(SelectedDate) >= 0 && termin.Beginning.CompareTo(SelectedDate.AddDays(1)) <= 0)
                {
                    CurrentAppoitments.Add(termin);
                }
            }
            if(CurrentAppoitments.Count>=1)
            {
            }
            
            //var date = (SelectedDate) sender;
            //SelecetedDate2.BorderBrush
            //SelectedDate = (Datesender;
        }

        private void Generate_Report(object sender, RoutedEventArgs e)
        {
            app.PrescriptionReportGenerator.Generate(null);
            var alert = new Doctor.Alert();
            alert.Show();
        }

        private void CooseRecepie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TartgetRosource = ComboBox12.SelectedValue.ToString().Remove(0, 38);
            //ComboBox12.SelectedValue.ToString();//.Remove(0, 38);
            Medicine_toAdd.Content = ComboBox12.SelectedValue.ToString().Remove(0, 38);
            Medicine_toAdd.Visibility = Visibility.Visible;
            NumberTextBox.Visibility = Visibility.Visible;
            NumberTextBox_Copy.Visibility = Visibility.Visible;
            Kol_med.Visibility = Visibility.Visible;
            Uc_med.Visibility = Visibility.Visible;
            AddMediciniToList.Visibility = Visibility.Visible;
        }

        private void AddLek(object sender, RoutedEventArgs e)
        {
            /*
            //ComboBox12.Items.Add(TartgetRosource);
            String oneRecepie = "";
            oneRecepie += TartgetRosource;
            oneRecepie += " ";
            if (Amount != 0)
            {
                oneRecepie +=  Amount.ToString();
            }
            if(Freq != 0)
            {
                oneRecepie += "x";
                oneRecepie += Freq.ToString();
            }
            Recepies.Add(oneRecepie);
            PecepiesList.Items.Add(oneRecepie);

            Medicine_toAdd.Visibility = Visibility.Hidden;
            NumberTextBox.Visibility = Visibility.Hidden;
            NumberTextBox_Copy.Visibility = Visibility.Hidden;
            Kol_med.Visibility = Visibility.Hidden;
            Uc_med.Visibility = Visibility.Hidden;
            AddMediciniToList.Visibility = Visibility.Hidden;*/
        }

        private void RemoveLek(object sender, RoutedEventArgs e)
        {/*
            var sellek = PecepiesList.SelectedItem;
            PecepiesList.Items.Remove(sellek);*/
        }




        private void Termini_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selitem = Termini.SelectedValue;
            if (CurrentAppoitments != null && CurrentAppoitments.Count() > 0)
            {
                BeginApp = ((MedicalAppointmentDTO)selitem).Beginning;
                EndApp = ((MedicalAppointmentDTO)selitem).End;
                if (((MedicalAppointmentDTO)selitem).Type != MedicalAppointmentType.operation)
                {
                    OperacijeTab.Visibility = Visibility.Hidden;
                }
                else
                {
                    OperacijeTab.Visibility = Visibility.Visible;

                }

                TypeOfTermin = ((MedicalAppointmentDTO)selitem).Type.ToString();
            }
        }

        private void Send_rep(object sender, RoutedEventArgs e)
        {
            var alert = new Alert();
            alert.Show();
            ListOfRosourcesesListOfResources.Items.Clear();
        }

        private void Prescribe_Clik(object sender, RoutedEventArgs e)
        {
            var alert = new Alert();
            alert.Show();
            PecepiesList.Items.Clear();
        }

        private void ListBox_Selected(object sender, RoutedEventArgs e)
        {
            //Req_medicine.Content = Select_prescr.SelectedItem as string;
            ListBox lb = sender as ListBox;
            Req_medicine.Content = lb.SelectedValue.ToString().Remove(0,37);
            //requiest = ;
        }

        private void Approve(object sender, RoutedEventArgs e)
        {
            var alert = new Alert();
            alert.Show();
            approve.Visibility = Visibility.Collapsed;
            reject.Visibility = Visibility.Visible;
        }

        private void Reject(object sender, RoutedEventArgs e)
        {
            var alert = new Alert();
            alert.Show();
            approve.Visibility = Visibility.Visible;
            reject.Visibility = Visibility.Collapsed;
        }

        private void Filter(object sender, RoutedEventArgs e)
        {
            Mira_Miric.Visibility = Visibility.Collapsed ;
            Mira_Miric1.Visibility = Visibility.Collapsed;
            Mira_Miric2.Visibility = Visibility.Collapsed;
            Uros_Milovanocic.Visibility = Visibility.Collapsed;

            //listOfPatients.
        }

        private void Change_selfCare(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            if(button.Content.ToString() == "Odjavi sa intezivne nege")
            {
                button.Content = "Dodaj na intezivnu negu";
            }
            else
            {
                button.Content = "Odjavi sa intezivne nege";
            }
        }
    }
}
