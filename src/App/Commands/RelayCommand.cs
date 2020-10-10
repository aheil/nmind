using System;
using System.Windows.Input;

namespace nMind.Commands
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private Action _execute;
        private Func<bool> _canExecute;

        public RelayCommand(Action execute)
           : this(execute, null)
        {
            // intentionally emtpy
        }

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute.Invoke() ;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke(); ;
        }
    }
}
