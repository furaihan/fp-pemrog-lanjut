using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace PinusPengger.UserControls
{
    /// <summary>
    /// Interaction logic for RoomRepresentation.xaml
    /// </summary>
    public partial class RoomRepresentation : UserControl
    {
        public RoomRepresentation()
        {
            InitializeComponent();
        }
        public Brush ButtonColor
        {
            get => (Brush)GetValue(ButtonColorProperty);
            set => SetValue(ButtonColorProperty, value);
        }
        public static readonly DependencyProperty ButtonColorProperty = DependencyProperty.Register("ButtonColor", typeof(Brush), typeof(RoomRepresentation));
        public string RoomNumber
        {
            get => (string)GetValue(RoomNumberProperty);
            set => SetValue(RoomNumberProperty, value);
        }
        public static readonly DependencyProperty RoomNumberProperty = DependencyProperty.Register("RoomNumber", typeof(string), typeof(RoomRepresentation));
    }
}
