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
    /// Interaction logic for SecretarySettings.xaml
    /// </summary>
    public partial class SecretarySettings : UserControl
    {
        public SecretarySettings()
        {
            InitializeComponent();
        }
        private void Change_Click(object sender, RoutedEventArgs e)
        {
            Profile_FirstName.IsEnabled = true;
            Profile_LastName.IsEnabled = true;
            Profile_Email.IsEnabled = true;
            Profile_Address.IsEnabled = true;
            Profile_TelephoneNumber.IsEnabled = true;
            Obustavi.Visibility = Visibility.Visible;
            Izmeni.Visibility = Visibility.Hidden;
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Profile_FirstName.IsEnabled = false;
            Profile_LastName.IsEnabled = false;
            Profile_Email.IsEnabled = false;
            Profile_Address.IsEnabled = false;
            Profile_TelephoneNumber.IsEnabled = false;
            Obustavi.Visibility = Visibility.Hidden;
            Izmeni.Visibility = Visibility.Visible;

        }
        private void Feedback_Click(object sender, RoutedEventArgs e)
        {
            var s = new FeedbackModal();
            s.Show();

        }
        private void Change_Picture(object sender, RoutedEventArgs e)
        {

        }
    }
}
