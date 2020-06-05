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
using MaterialDesignThemes.Wpf.Transitions;
using Project.Repositories;
using Project.Views.Model;
using Project.Views.Tabs;

namespace Project.Views.Secretary
{
    /// <summary>
    /// Interaction logic for DoctorSearchModal.xaml
    /// </summary>
    public partial class DoctorSearchModal : Window
    {
        public ObservableCollection<DoctorDTO> Doctors { get; set; }

        public DoctorSearchModal()
        {
            this.DataContext = this;
            var app = System.Windows.Application.Current as App;
            Doctors = new ObservableCollection<DoctorDTO>
            {
                new DoctorDTO() { Id = 0, FirstName = "Nikola", LastName = "Selic" },
                new DoctorDTO() { Id = 1, FirstName = "Nikola", LastName = "Selic" },
                new DoctorDTO() { Id = 2, FirstName = "Nikola", LastName = "Selic" },
                new DoctorDTO() { Id = 3, FirstName = "Nikola", LastName = "Selic" }
            };

        }

        private void DoctorList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
