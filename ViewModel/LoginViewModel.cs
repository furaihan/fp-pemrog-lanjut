using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PinusPengger.Records;

namespace PinusPengger.ViewModel
{
    internal class LoginViewModel : ViewModelBase
    {
        private ICommand loginCommand;
        private ICommand showPasswordCommand;
        private UserRecord _entity;

        //Command
        public ICommand LoginCommand 
        { 
            get => loginCommand; 
            set => loginCommand = value; 
        }
        public ICommand ShowPasswordCommand 
        { 
            get => showPasswordCommand; 
            set => showPasswordCommand = value;
        }

        public LoginViewModel()
        {
            _entity = new UserRecord();
        }
        private bool CanExecuteLoginCommand()
        {
            UserRecord user = new UserRecord();
            bool valid = !string.IsNullOrWhiteSpace(user.Username) &&
                !string.IsNullOrWhiteSpace(user.Password) &&
                user.Username.Length > 3 &&
                user.Password.Length > 3;
            if (!valid)
            {
                user.ErrorMessage = "Invalid username or password";
            }
            return valid;
        }
        private void ExecuteLoginCommand()
        {
        }
    }
}
