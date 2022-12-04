using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PinusPengger.ViewModel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowController : Window
    {
        public MainWindowController()
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
            if (e.LeftButton== MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}