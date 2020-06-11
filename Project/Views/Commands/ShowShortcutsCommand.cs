using LiveCharts.Wpf;
using MaterialDesignThemes.Wpf;
using Project.Views.Secretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Project.Views.Commands
{
    public class ShowShortcutsCommand : ICommand
    {
        public void Execute(object parameter)
        {
            string msg;

            if (parameter.Equals("Shortcuts"))
            {
                Shortcuts s = new Shortcuts();
                s.Show();
            }
            else if (parameter.Equals("Help"))
            {
                Shortcuts s = new Shortcuts();
                s.Show();

            }
            else if (parameter.Equals("CreateAppointment"))
            {
                ShortcutsModal s = new ShortcutsModal();
                s.Show();

            }
            else
            {
                msg = parameter.ToString();
                MessageBox.Show(msg);
            }

        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}
