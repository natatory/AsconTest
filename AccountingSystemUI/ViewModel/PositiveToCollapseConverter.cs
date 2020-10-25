using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using AccountingSystemDAL.Model;

namespace AccountingSystemUI.ViewModel
{
    class PositiveToCollapseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is decimal && ((decimal)value < 0) ?
                Visibility.Visible
                : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
