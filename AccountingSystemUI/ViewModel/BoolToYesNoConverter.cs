using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using AccountingSystemDAL.Model;

namespace AccountingSystemUI.ViewModel
{
    class BoolToYesNoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
                return ((bool)value) == true ? "Да" : "Нет";
            return null;
                    
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
