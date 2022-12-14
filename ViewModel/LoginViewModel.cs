using PinusPengger.Records;
using PinusPengger.View;
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
        #endregion

        //Command

        public LoginViewModel()
        {
            UserRecEntity = new UserRecord();
            _loginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
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
            var win = obj as LoginWindow;
            win?.Close();
        }
    }
}
