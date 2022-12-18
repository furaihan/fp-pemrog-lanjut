using PinusPengger.ViewModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace PinusPengger.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            Debug.WriteLine("AFTER IC");
            (DataContext as LoginViewModel).CloseWindow = () => Close();
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
            // blank
        }
    }
}
