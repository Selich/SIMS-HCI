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
    /// Interaction logic for RenovationModal.xaml
    /// </summary>
    public partial class RenovationModal : Window
    {
           
        public RenovationModal()
        {
            InitializeComponent();
        }

        private void AdjustRenovationModal(object sender, SelectionChangedEventArgs e)
        {

            var item = ((ComboBoxItem)((sender as ComboBox).SelectedItem)).Content; 
            if(item != null)
            {
                string text = item.ToString();

            if (text != null && RoomType!=null && NewRoomType!=null) { 
                if (text.Equals("Promena funkcije"))
                {
                    RoomType.IsEnabled = true;
                    NewRoomType.IsEnabled = false;
                }
                else if (text.Equals("Pregradjivanje"))
                {
                    RoomType.IsEnabled = false;
                    NewRoomType.IsEnabled = true;
                } 
                else
                {
                    RoomType.IsEnabled = false;
                    NewRoomType.IsEnabled = false;

                }
           
             }
            }
        }

        private void CloseRenovationAppointment(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}