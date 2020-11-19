using System;
using System.Windows.Data;
using System.Globalization;
using AccountingSystemDAL.Model;

namespace AccountingSystemUI.ViewModel
{
    public class EnumDescriptionConverter : IValueConverter
    {
        //From Binding Source
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Enum)) throw new ArgumentException("Value is not an Enum");
            return UIEnumHelper.GetDescription(value as Enum);
        }

        //From Binding Target
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string)) throw new ArgumentException("Value is not a string");
            foreach (var item in Enum.GetValues(targetType))
            {
                var asString = UIEnumHelper.GetDescription(item as Enum);
                if (asString == (string)value)
                {
                    return item;
                }
            }
            throw new ArgumentException("Unable to match string to Enum description");
        }
    }
}
