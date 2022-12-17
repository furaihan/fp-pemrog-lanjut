using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PinusPengger.UserControls
{
    /// <summary>
    /// Interaction logic for RegularRoom.xaml
    /// </summary>
    public partial class RegularRoom : UserControl
    {
        public RegularRoom()
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
                                                                                                        typeof(RegularRoom));
        public Brush ButtonColor
        {
            get => (Brush)GetValue(ButtonColorProperty);
            set => SetValue(ButtonColorProperty, value);
        }
        public static readonly DependencyProperty ButtonColorProperty = DependencyProperty.Register("ButtonColor", typeof(Brush), typeof(RegularRoom));
    }
}
