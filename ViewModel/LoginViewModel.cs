using PinusPengger.View;
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace PinusPengger.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        /*
        public LoginViewModel()
        {
            _loginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            Debug.WriteLine($"HOOOI");
        }
        */
        #region Field
        private string _username;
        private string _password;
        private string _errorMessage;
        private ICommand _loginCommand;
        private ICommand _showPasswordCommand;
        #endregion

        #region Properties
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }
        /*
        public ICommand LoginCommand
        {
            get => _loginCommand;
            set => _loginCommand = value;
        } 
        */
        public ICommand LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                {
                    _loginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
                }
                return _loginCommand;
            }
        }
        public ICommand ShowPasswordCommand
        {
            get => _showPasswordCommand;
            set => _showPasswordCommand = value;
        }
        public Action CloseWindow { get; set; }
        #endregion

        //Command

        private bool CanExecuteLoginCommand(object obj)
        {
            bool valid = !string.IsNullOrWhiteSpace(Username) &&
                !string.IsNullOrWhiteSpace(Password) &&
                Username.Length > 3 &&
                Password.Length > 3;
            Debug.WriteLine($"Name set: {Username}");
            Debug.WriteLine($"Password set: {Password}");
            Debug.WriteLine($"Valid: {valid}");
            return valid;
        }
        private void ExecuteLoginCommand(object obj)
        {
            if (Password.ToLower() == "admin" && Username.ToLower() == "admin")
            {
                MainWindow mainWindow = new MainWindow();
                CloseWindow();
                mainWindow.Show();
            }
            else
            {
                ErrorMessage = "Invalid username or password";
            }

        }
    }
}
