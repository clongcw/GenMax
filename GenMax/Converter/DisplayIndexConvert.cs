using System;
using System.Globalization;

namespace GenMax.Converter
{
    public class DisplayIndexConvert : ValueConverterBase<DisplayIndexConvert>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var id = (int)value;
                return id + 1;
            }
            else
            {
                return 1;
            }
        }
    }
}
