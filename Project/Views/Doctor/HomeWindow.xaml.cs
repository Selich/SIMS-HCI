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

namespace Project.Views.Doctor
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        //private bool _isEditMod = true;

        public HomeWindow()
        {
            InitializeComponent();
        }
        /*
        public bool EditModBool
        {
            get { return _isEditMod; }
        }*/
        
        private void ChangeMode_Click(object sender, RoutedEventArgs e)
        {
            label1.Visibility = Visibility.Collapsed;
            //_isEditMod = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
