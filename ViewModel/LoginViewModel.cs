using PinusPengger.View;
using System;
using System.Diagnostics;

namespace PinusPengger.ViewModel
{
    ///<summary>
    ///The ViewModel for the Login page.
    ///</summary>
    public class LoginViewModel : ViewModelBase
    {
        ///<summary>
        ///Initializes a new instance of the LoginViewModel class with default values.
        ///</summary>
        public LoginViewModel()
        {
            _username = string.Empty;
            _password = string.Empty;
            _errorMessage = string.Empty;
            _loginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
        }
        #region Field
        private string _username;
        private string _password;
        private string _errorMessage;
        private ViewModelCommand _loginCommand;
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
        public ViewModelCommand LoginCommand
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
        /// <summary>
        /// Executes the login command
        /// </summary>
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
