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
    public partial class SecretaryQuestions : UserControl
    {
        public QuestionDTO CurrentQuestion;

        public SecretaryQuestions()
        {
            var app = Application.Current as App;
            InitializeComponent();

            QuestionsList.ItemsSource = app.QuestionController.GetAll();
            SelectedQuestion.Visibility = Visibility.Hidden;

        }
        private void Feedback_Click(object sender, RoutedEventArgs e)
            => new FeedbackModal().Show();

        private void Profile_Click(object sender, RoutedEventArgs e)
            => new FeedbackModal().Show();

        private void QuestionsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentQuestion = (QuestionDTO)QuestionsList.SelectedItem;
            SelectedQuestion.Visibility = Visibility.Visible;
            Question.Text = CurrentQuestion.QuestionText;
            Answer.Text = CurrentQuestion.AnswerText;
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Question_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
