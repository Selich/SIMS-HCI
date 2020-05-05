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

namespace Project.Views.Director
{
    /// <summary>
    /// Interaction logic for EmployeeDataModal.xaml
    /// </summary>
    public partial class EmployeeDataModal : Window
    {
        public EmployeeDataModal()
        {
            InitializeComponent();
        }

        private void SaveEmployeeDataChanges(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CancelEmployeeDataChanges(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
