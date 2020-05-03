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

namespace Project.Views.Patient
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
        }

        private void Feedback_Click(object sender, RoutedEventArgs e)
        {
            var s = new Patient.Feedback();
            s.Show();
        }

        private void FAQ_Click(object sender, RoutedEventArgs e)
        {
            var s = new Patient.FAQ();
            s.Show();
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            var s = new Patient.History();
            s.Show();
        }

        private void Doctor_Click(object sender, RoutedEventArgs e)
        {
            var s = new Patient.Doctor();
            s.Show();
        }
    }
}
