using System;
using System.Globalization;
using System.Windows.Data;
using AccountingSystemDAL.Model;

namespace AccountingSystemUI.ViewModel
{
    class CategoryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return new Category
                {
                    CategoryId = Guid.NewGuid(),
                    Name = value.ToString().Trim()
                };
            else return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
