using nMind.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace nMind.ViewModels
{
    public class MenuItemViewModel
    {
        private readonly ICommand _command;

        public string Header { get; set; }

        public IView View { get; set; } 

        public MenuItemViewModel()
        {

        }

        public MenuItemViewModel(ICommand command)
        {
            _command = command;
        }
    }
}
