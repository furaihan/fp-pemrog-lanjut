using PinusPengger.Records;
using System.Windows.Input;

namespace PinusPengger.ViewModel
{
    internal class LoginViewModel : ViewModelBase
    {
        #region Field
        private ICommand _loginCommand;
        private ICommand _showPasswordCommand;
        #endregion

        #region Properties
        public UserRecord UserRecEntity { get; set; }
        public ICommand LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                {
                    _loginCommand = new ViewModelCommand(param => ExecuteLoginCommand(), param => CanExecuteLoginCommand());
                }

                return _loginCommand;
            }
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
        }
        private bool CanExecuteLoginCommand()
        {
            bool valid = !string.IsNullOrWhiteSpace(UserRecEntity.Username) &&
                !string.IsNullOrWhiteSpace(UserRecEntity.Password) &&
                UserRecEntity.Username.Length > 3 &&
                UserRecEntity.Password.Length > 3;
            if (!valid)
            {
                UserRecEntity.ErrorMessage = "Invalid username or password";
            }
            return valid;
        }
        private void ExecuteLoginCommand()
        {
        }
    }
}
