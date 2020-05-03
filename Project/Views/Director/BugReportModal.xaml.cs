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
    /// Interaction logic for BugReportModal.xaml
    /// </summary>
    public partial class BugReportModal : Window
    {
        public BugReportModal()
        {
            InitializeComponent();
        }

        private void ConfirmBugReport(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CancelBugReport(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

     
    }
}
