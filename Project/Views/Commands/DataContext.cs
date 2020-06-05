using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.Views.Commands
{
    public class DataContext
    {
        ICommand _messageCommand = new MessageCommand();
        ICommand _shortcutCommand = new ShowShortcutsCommand();

        public ICommand MessageCommand
        {
            get { return _messageCommand; }
        }
        public ICommand ShowShortcutsCommand
        {
            get { return _shortcutCommand; }
        }
    }
}
