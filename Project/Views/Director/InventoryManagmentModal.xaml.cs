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

namespace Project.Views.Director
{
    /// <summary>
    /// Interaction logic for InventoryManagmentModal.xaml
    /// </summary>
    public partial class InventoryManagmentModal : Window
    {
        public InventoryManagmentModal()
        {
            InitializeComponent();
            List<Equipment> equipment = new List<Equipment>();
            equipment.Add(new Equipment() { name="Sto", type = "namestaj" });
            equipment.Add(new Equipment() { name = "Stolica", type = "namestaj" });
            equipment.Add(new Equipment() { name="Cekic", type = "alat/oruzje"});

            DataGridExample.ItemsSource = equipment;
        }

        private void CloseInventoryManagment(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
