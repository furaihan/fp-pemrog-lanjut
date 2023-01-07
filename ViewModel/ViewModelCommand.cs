using System;
using System.Windows.Input;

namespace PinusPengger.ViewModel
{
    public class ViewModelCommand : ICommand
    {
        private Action<object>? _execute;
        private Func<object, bool>? _canExecute;

        public ViewModelCommand(Action<object> execute, Func<object, bool>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }
    }
}
