using PinusPengger.View;
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace PinusPengger.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        #region Field
        private string _username;
        private string _password;
        private string _errorMessage;
        private ICommand _loginCommand;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the username of the user
        /// </summary>
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Gets or sets the password of the user
        /// </summary>
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Gets or sets the error message that will be displayed in login view
        /// </summary>
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Gets or sets the login command
        /// </summary>
        public ICommand LoginCommand
        {
            get
            {
                _loginCommand ??= new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
                return _loginCommand;
            }
        }
        public Action CloseWindow { get; set; }
        #endregion

        #region Method
        /// <summary>
        /// Determines whether the <see cref="ExecuteLoginCommand(object)"/> can be executed
        /// </summary>
        /// <param name="obj">CommandParam object</param>
        /// <returns><c>true</c> if the <see cref="ExecuteLoginCommand(object)"/> can be executed, otherwise <c>false</c></returns>
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
        #endregion
    }
}
