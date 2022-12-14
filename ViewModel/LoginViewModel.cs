using PinusPengger.Records;
using PinusPengger.View;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace PinusPengger.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        #region Field
        private ICommand _loginCommand;
        private ICommand _showPasswordCommand;
        private UserRecord userRecEntity;
        #endregion

        #region Properties
        public UserRecord UserRecEntity
        {
            get => userRecEntity;
            set
            {
                userRecEntity = value;
                OnPropertyChanged();
            }
        }
        public ICommand LoginCommand
        {
            get => _loginCommand;
            set => _loginCommand = value;
        }
        public ICommand ShowPasswordCommand
        {
            get => _showPasswordCommand;
            set => _showPasswordCommand = value;
        }
        public Action CloseWindow { get; set; }
        #endregion

        //Command

        public LoginViewModel()
        {
            userRecEntity = new UserRecord();
            _loginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            Debug.WriteLine($"HOOOI");
        }
        private bool CanExecuteLoginCommand(object obj)
        {
            bool valid = !string.IsNullOrWhiteSpace(UserRecEntity.Username) &&
                !string.IsNullOrWhiteSpace(UserRecEntity.Password) &&
                UserRecEntity.Username.Length > 3 &&
                UserRecEntity.Password.Length > 3;
            Debug.WriteLine($"Name set: {UserRecEntity.Username}");
            Debug.WriteLine($"Password set: {userRecEntity.Password}");
            Debug.WriteLine($"Valid: {valid}");
            return valid;
        }
        private void ExecuteLoginCommand(object obj)
        {
            if (userRecEntity.Password.ToLower() == "admin" && userRecEntity.Username.ToLower() == "admin")
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                CloseWindow();
            }
            else
            {
                userRecEntity.ErrorMessage = "Invalid username or password";
            }
            
        }
    }
}
