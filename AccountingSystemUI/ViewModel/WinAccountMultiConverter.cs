using System;
using System.Globalization;
using System.Windows.Data;
using AccountingSystemUI.Application;

namespace AccountingSystemUI.ViewModel
{
    class WinAccountMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return new WinAccount
                {
                    Name = values[0].ToString().Trim(),
                    IsAdmin = (bool)values[1]
                };
            }
            //there is no need for a reaction, just skip the casting errors
            //until the full set of user inputs (error less) is reached 
            catch (Exception ex)
            {
                return null;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}