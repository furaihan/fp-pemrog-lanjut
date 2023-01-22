using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using PinusPengger.Model;

namespace PinusPengger.ViewModel.Helper
{
    public class RoomTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (Tag.RoomType)value;
            var ret = type switch
            {
                Tag.RoomType.REG => "Reguler",
                Tag.RoomType.VIP => "Presidential Suite / VIP",
                _ => ""
            };
            return ret;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
