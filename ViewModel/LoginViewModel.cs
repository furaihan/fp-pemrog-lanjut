using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PinusPengger.ViewModel
{
    internal class LoginViewModel : ViewModelBase
    {
        private string username;
        private string password;
        private string errorMessage;

        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }
        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                OnPropertyChanged();
            }
        }

        //Command
        public ICommand LoginCommand { get; set; }
        public ICommand ShowPasswordCommand { get; set; }

        private bool CanExecuteLoginCommand()
        {
            bool valid = !string.IsNullOrWhiteSpace(username) &&
                !string.IsNullOrWhiteSpace(password) &&
                username.Length > 3 &&
                password.Length > 3;
            if (!valid)
            {
                ErrorMessage = "Invalid username or password";
            }
            return valid;
        }
    }
}
