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
    /// <summary>
    /// A value converter that converts a room type value from an enumeration into a user-friendly string representation.
    /// </summary>
    public class RoomTypeConverter : IValueConverter
    {
        /// <summary>
        /// Converts a room type value from an enumeration into a user-friendly string representation.
        /// </summary>
        /// <param name="value">The room type value to convert.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A user-friendly string representation of the room type.</returns>
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
        /// <summary>
        /// Converts a user-friendly string representation of a room type into a room type value from an 
        /// </summary>
        /// <remarks>
        /// <b>This method is not implemented and always throws a NotImplementedException.</b>
        /// </remarks>
        /// <param name="value">The user-friendly string representation of the room type to convert back.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>The room type value from the enumeration.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
