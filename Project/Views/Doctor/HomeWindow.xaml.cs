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


namespace Project.Views.Doctor
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        //private bool _isEditMod = true;
        public bool togg;

        public HomeWindow()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();

            HideTextBoxes();
            HidePlaceHolders();

            saveEdit.Visibility = Visibility.Collapsed;
            cancleEdit.Visibility = Visibility.Collapsed;
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

            SetPlaceHoldersAsLabels();

            saveEdit.Visibility = Visibility.Visible;

            cancleEdit.Visibility = Visibility.Visible;
            buttonEdit.Visibility = Visibility.Collapsed;
            //_isEditMod = false;
        }

        private void SetPlaceHoldersAsLabels()
        {
            textbox1p.Text = label0.Text;
            textbox2p.Text = label1.Text;
            textbox3p.Text = label2.Text;
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

        private void JMBGValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]{8}");
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
            textbox1.Text = "";
            textbox1.Visibility = Visibility.Visible;
            textbox1p.Visibility = Visibility.Collapsed;
            Keyboard.Focus(textbox1);
        }
        private void Textbox2p_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textbox2.Text = "";
            textbox2.Visibility = Visibility.Visible;
            textbox2p.Visibility = Visibility.Collapsed;
            Keyboard.Focus(textbox2);
        }
        private void Textbox3p_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textbox3.Text = "";
            textbox3.Visibility = Visibility.Visible;
            textbox3p.Visibility = Visibility.Collapsed;
            Keyboard.Focus(textbox3);
        }
        private void Textbox4p_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textbox4.Text = "";
            textbox4.Visibility = Visibility.Visible;
            textbox4p.Visibility = Visibility.Collapsed;
            Keyboard.Focus(textbox4);
        }
        private void Textbox5p_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textbox5.Text = "";
            textbox5.Visibility = Visibility.Visible;
            textbox5p.Visibility = Visibility.Collapsed;
            Keyboard.Focus(textbox5);
        }
        private void Textbox6p_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textbox6.Text = "";
            textbox6.Visibility = Visibility.Visible;
            textbox6p.Visibility = Visibility.Collapsed;
            Keyboard.Focus(textbox6);
        }
        private void Textbox7p_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textbox7.Text = "";
            textbox7.Visibility = Visibility.Visible;
            textbox7p.Visibility = Visibility.Collapsed;
            Keyboard.Focus(textbox7);

        }
        private void Textbox8p_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textbox8.Text = "";
            textbox8.Visibility = Visibility.Visible;
            textbox8p.Visibility = Visibility.Collapsed;
            Keyboard.Focus(textbox8);
        }
        private void Textbox9p_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textbox9.Text = "";
            textbox9.Visibility = Visibility.Visible;
            textbox9p.Visibility = Visibility.Collapsed;
            Keyboard.Focus(textbox9);
        }
    }
}
