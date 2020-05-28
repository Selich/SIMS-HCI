using Project.Views.Secretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Project.Views.Templates
{
    partial class Details : ResourceDictionary
    {
        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            Model.Guest item = (Model.Guest)(sender as System.Windows.Controls.Button).DataContext;
            var s = new ProfileModal(item);
            s.Show();

        }
    }
}
