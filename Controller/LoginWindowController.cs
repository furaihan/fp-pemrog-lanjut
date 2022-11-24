using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace PinusPengger.Controller
{
    /// <summary>
    /// Interaction logic for HistoryView2.xaml
    /// </summary>
    public partial class LoginWindowController : Window, INotifyPropertyChanged
    {
        public LoginWindowController()
        {
            InitializeComponent();
        }
  

        private void CloseApp(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void MinimizeApp(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void DragApp(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void LoginClick(object sender, RoutedEventArgs e)
        {
            if (usernameBox.Text.ToLower() == "admin" && passwdBox.Text.ToLower() == "admin")
            {
                MainWindowController mainWindow = new MainWindowController();
                mainWindow.Show();
                this.Close();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

