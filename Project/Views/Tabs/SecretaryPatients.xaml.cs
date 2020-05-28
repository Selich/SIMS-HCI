using Project.Views.Secretary;
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
    /// Interaction logic for SecretaryPatients.xaml
    /// </summary>
    public partial class SecretaryPatients : UserControl
    {
        public SecretaryPatients()
        {
            InitializeComponent();
        }
        private void Feedback_Click(object sender, RoutedEventArgs e)
        {
            var s = new FeedbackModal();
            s.Show();

        }
        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            //CollectionViewSource.GetDefaultView(listPatients.ItemsSource).Refresh();
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            //drLabel2.Content = null;

        }

        private void CreatePatient_Click(object sender, RoutedEventArgs e)
        {
            var s = new CreatePatientModal();
            s.Show();

        }
    }
}
