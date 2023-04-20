using System;
using System.Windows.Input;

namespace PinusPengger.ViewModel
{
    ///<summary>
    ///A class for implementing a command that can be used in a 
    ///ViewModel to bind to UI elements such as buttons, menu items, etc.
    ///</summary>
    public class ViewModelCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;
        ///<summary>
        ///Creates an instance of a ViewModelCommand with an action to be executed 
        ///and an optional function to determine if the command can be executed.
        ///</summary>
        ///<param name="execute">The action to execute when the command is invoked.</param>
        ///<param name="canExecute">The function to determine if the command can be executed.</param>
        public ViewModelCommand(Action<object> execute, Func<object, bool>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        ///<summary>
        ///Occurs when changes occur that affect whether or not the command should execute.
        ///</summary>
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        ///<summary>
        ///Defines the method to be called when the command is invoked.
        ///</summary>
        ///<param name="parameter">Data used by the command. 
        ///If the command does not require data to be passed, 
        ///this object can be set to null.</param>
        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
        ///<summary>
        ///Defines the method that determines whether the command can execute in its current state.
        ///</summary>
        ///<param name="parameter">Data used by the command. 
        ///If the command does not require data to be passed, 
        ///this object can be set to null.</param>
        ///<returns>true if this command can be executed; otherwise, false.</returns>
        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }
    }
}
