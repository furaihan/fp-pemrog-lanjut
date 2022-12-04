using System;
using System.Windows.Input;

namespace PinusPengger.ViewModel
{
    internal class ViewModelCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public ViewModelCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
