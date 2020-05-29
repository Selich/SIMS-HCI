﻿using Project.Model;
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
    /// Interaction logic for SecretaryQuestions.xaml
    /// </summary>
    public partial class SecretaryQuestions : UserControl
    {
        private Question selectedQuestion;

        public SecretaryQuestions()
        {
            InitializeComponent();
        }
        private void QuestionsList_KeyDown(object sender, KeyboardEventArgs e)
        {
            selectedQuestion = (Question)listQuestions.SelectedItem;
            var modal = new QuestionModal(selectedQuestion);
            modal.Show();


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
    }
}