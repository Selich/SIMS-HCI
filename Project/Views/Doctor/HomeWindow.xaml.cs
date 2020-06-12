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


            textbox1.Visibility = Visibility.Collapsed;
            textbox2.Visibility = Visibility.Collapsed;
            textbox3.Visibility = Visibility.Collapsed;
            textbox4.Visibility = Visibility.Collapsed;
            textbox5.Visibility = Visibility.Collapsed;
            textbox6.Visibility = Visibility.Collapsed;
            textbox7.Visibility = Visibility.Collapsed;
            textbox8.Visibility = Visibility.Collapsed;
            textbox9.Visibility = Visibility.Collapsed;
            saveEdit.Visibility = Visibility.Collapsed;
            cancleEdit.Visibility = Visibility.Collapsed;
        }
        /*
        public bool EditModBool
        {
            get { return _isEditMod; }
        }*/
        
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

            textbox1.Visibility = Visibility.Visible;
            textbox2.Visibility = Visibility.Visible;
            textbox3.Visibility = Visibility.Visible;
            textbox4.Visibility = Visibility.Visible;
            textbox5.Visibility = Visibility.Visible;
            textbox6.Visibility = Visibility.Visible;
            textbox7.Visibility = Visibility.Visible;
            textbox8.Visibility = Visibility.Visible;
            textbox9.Visibility = Visibility.Visible;

            textbox1.Text = label0.Text;
            textbox2.Text = label1.Text;
            textbox3.Text = label2.Text;
            textbox4.Text = label6.Text;
            textbox5.Text = label7.Text;
            textbox6.Text = label8.Text;
            textbox7.Text = label3.Text;
            textbox8.Text = label4.Text;
            textbox9.Text = label5.Text;
            
            saveEdit.Visibility = Visibility.Visible;

            cancleEdit.Visibility = Visibility.Visible;
            buttonEdit.Visibility = Visibility.Collapsed;
            //_isEditMod = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
             //
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
            textbox1.Visibility = Visibility.Collapsed;
            textbox2.Visibility = Visibility.Collapsed;
            textbox3.Visibility = Visibility.Collapsed;
            textbox4.Visibility = Visibility.Collapsed;
            textbox5.Visibility = Visibility.Collapsed;
            textbox6.Visibility = Visibility.Collapsed;
            textbox7.Visibility = Visibility.Collapsed;
            textbox8.Visibility = Visibility.Collapsed;
            textbox9.Visibility = Visibility.Collapsed;
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
            textbox1.Visibility = Visibility.Collapsed;
            textbox2.Visibility = Visibility.Collapsed;
            textbox3.Visibility = Visibility.Collapsed;
            textbox4.Visibility = Visibility.Collapsed;
            textbox5.Visibility = Visibility.Collapsed;
            textbox6.Visibility = Visibility.Collapsed;
            textbox7.Visibility = Visibility.Collapsed;
            textbox8.Visibility = Visibility.Collapsed;
            textbox9.Visibility = Visibility.Collapsed;
            saveEdit.Visibility = Visibility.Collapsed;
            cancleEdit.Visibility = Visibility.Collapsed;
            buttonEdit.Visibility = Visibility.Visible;
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            var s = new Doctor.HistoryPatient();
            s.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }






        // TODO delete
        private void NumberTextBox_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (!NumberTextBox.Text.Equals(""))
            {
                NumberTextBox.Text = (Int32.Parse(NumberTextBox.Text) + 1).ToString();
            }
        }

        // TODO delete
        private void NumberTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!NumberTextBox.Text.Equals(""))
            {
                NumberTextBox.Text = (Int32.Parse(NumberTextBox.Text) - 1).ToString();
            }
        }

        private void Alert_Click(object sender, RoutedEventArgs e)
        {
            var alert = new Doctor.Alert();
            alert.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Wizard_Click(object sender, RoutedEventArgs e)
        {
            var wizard = new WizardWindow();
            wizard.Show();
            Close();
        }
        /*
        private void Switch_Click(object sender, RoutedEventArgs e)
        {
            if(Switch.IsChecked ==  true)
            {
                //buttonEdit.ToolTip="";
                //buttonEdit.ToolTi ShowOnDisabled = "True";
                togg = true;
            }
            else
            {
                togg = false;
            }
        }*/
    }
}
