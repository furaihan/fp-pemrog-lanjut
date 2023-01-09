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
        public DropShadowEffect DropShadowEffect
        {
            get => (DropShadowEffect)GetValue(DropShadowEffectProperty);
            set => SetValue(DropShadowEffectProperty, value);
        }
        public static readonly DependencyProperty DropShadowEffectProperty = DependencyProperty.Register("DropShadowEffect",
                                                                                                        typeof(DropShadowEffect),
                                                                                                        typeof(RoomRepresentation));
        public Brush ButtonColor
        {
            get => (Brush)GetValue(ButtonColorProperty);
            set => SetValue(ButtonColorProperty, value);
        }
        public static readonly DependencyProperty ButtonColorProperty = DependencyProperty.Register("ButtonColor", typeof(Brush), typeof(RoomRepresentation));
    }
}
