using Project.Model;
using Project.Views.Model;
using Project.Views.Secretary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for SecretaryQuestions.xaml
    /// </summary>
    public partial class SecretaryQuestions : UserControl
    {
        public QuestionDTO CurrentQuestion { get; set; }

        public SecretaryQuestions()
        {
            var app = Application.Current as App;
            InitializeComponent();

            QuestionsList.ItemsSource = app.QuestionController.GetAll();
            CurrentQuestion = null;
            SelectedQuestion.Visibility = Visibility.Hidden;

        }
        private void QuestionsList_KeyDown(object sender, KeyboardEventArgs e)
        {
        }
        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            //CollectionViewSource.GetDefaultView(listPatients.ItemsSource).Refresh();
        }
        private void Feedback_Click(object sender, RoutedEventArgs e)
        {
            var s = new FeedbackModal();
            s.Show();

        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            var s = new FeedbackModal();
            s.Show();

        }
    }
}
