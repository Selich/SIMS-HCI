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
    /// Interaction logic for OrderMedicineModal.xaml
    /// </summary>
    public partial class OrderMedicineModal : Window
    {
        public OrderMedicineModal()
        {
            InitializeComponent();
        }

        private void CloseMedicineOrder(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
    }
}
