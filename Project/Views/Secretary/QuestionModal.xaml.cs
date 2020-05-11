using Model;
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

namespace Project.Views.Secretary
{
    /// <summary>
    /// Interaction logic for QuestionModal.xaml
    /// </summary>
    public partial class QuestionModal : Window
    {
        public QuestionModal(Question q)
        {
            InitializeComponent();
            selectedQuestion.Content = q;
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
