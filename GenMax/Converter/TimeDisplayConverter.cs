using System;
using System.Globalization;

namespace GenMax.Converter
{
    public class TimeDisplayConverter : ValueConverterBase<TimeDisplayConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strTime = string.Empty;
            if (value != null)
            {
                double time;
                if (double.TryParse(value.ToString(), out time))
                {
                    int hour = (int)time / 3600;
                    int minute = (int)(time - hour * 3600) / 60;
                    int second = (int)(time - hour * 3600 - minute * 60);
                    strTime = string.Format("{0:D2}:{1:D2}:{2:D2}", hour, minute, second);
                    if (parameter != null)
                    {
                        var isOnlyMS = bool.Parse(parameter.ToString());
                        if (isOnlyMS)
                        {
                            strTime = string.Format("{0:D2}:{1:D2}", minute, second);
                        }
                    }
                }
            }
            return strTime;
        }
    }
}
