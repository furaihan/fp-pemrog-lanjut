using PinusPengger.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PinusPengger.ViewModel.Converter
{
    internal class RoomConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Room room)
            {
                char typeRoom = room.Type switch
                {
                    RoomType.Reguler => 'R',
                    RoomType.VIP => 'V',
                    RoomType.VVIP => 'P',
                    _ => 'R',
                };
                return $"{typeRoom}.{room.RoomNumber.Floor}.{room.RoomNumber.RoomNumber}";
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
