using Project.Views.Secretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Project.Views.Model;

namespace Project.Views.Templates
{
    partial class Details : ResourceDictionary
    {
        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            GuestDTO item = (GuestDTO)(sender as System.Windows.Controls.Button).DataContext;
            var s = new ProfileModal(item);
            s.Show();

        }
    }
}
