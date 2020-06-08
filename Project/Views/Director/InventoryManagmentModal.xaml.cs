using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        Point startPoint = new Point();

        public ObservableCollection<EquipmentDTO> Equipment
        {
            get;
            set;
        }

        public ObservableCollection<EquipmentDTO> Equipment2
        {
            get;
            set;
        }

        public InventoryManagmentModal()
        {
            
            InitializeComponent();
            this.DataContext = this;
            ObservableCollection<EquipmentDTO> l1 = new ObservableCollection<EquipmentDTO>();
            l1.Add(new EquipmentDTO() { Name = "Sto", Type = "namestaj" });
            l1.Add(new EquipmentDTO() { Name = "Stolica", Type = "namestaj" });
            l1.Add(new EquipmentDTO() { Name="Cekic", Type = "alat/oruzje"});

            ObservableCollection<EquipmentDTO> l2 = new ObservableCollection<EquipmentDTO>();
            l2.Add(new EquipmentDTO() { Name = "Makaze", Type = "alat" });
            l2.Add(new EquipmentDTO() { Name = "Cekic", Type = "alat" });
            l2.Add(new EquipmentDTO() { Name = "Cekic", Type = "alat/oruzje" });

            Equipment = new ObservableCollection<EquipmentDTO>(l1);
            Equipment2 = new ObservableCollection<EquipmentDTO>(l2);

     
        }

        private void ListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void ListView_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged ListViewItem
                DataGrid dgrid = sender as DataGrid;
                DataGridRow item =
                    FindAncestor<DataGridRow>((DependencyObject)e.OriginalSource);

                if (item == null) return;

                // Find the data behind the ListViewItem
                EquipmentDTO equip = (EquipmentDTO)dgrid.ItemContainerGenerator.
                    ItemFromContainer(item);

                // Initialize the drag & drop operation
                DataObject dragData = new DataObject("myFormat", equip);
                DragDrop.DoDragDrop(item, dragData, DragDropEffects.Move);
            }
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        private void ListView_DragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || e.Source == sender)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void ListView_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                EquipmentDTO equip = e.Data.GetData("myFormat") as EquipmentDTO;
                Equipment.Remove(equip);
                Equipment2.Add(equip);
            }
        }

        private void CloseInventoryManagment(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
