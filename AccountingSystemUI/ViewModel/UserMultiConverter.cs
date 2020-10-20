using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using AccountingSystemDAL.Model;

namespace AccountingSystemUI.ViewModel
{
    class UserMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //Boolean values (validation errors) are expected in the input from Button.CommandParameter.
            //The same array (values) is used to pass user input
            
            //check first 5 incoming values which contain validation result  
            
            for (var i = 0; i < 5; i++)
            {
                if ((bool)values[i]) return null;
            };
            try
            {
                return new User
                {
                    WinUserName = values[5].ToString(),
                    FirstName = values[6].ToString().Trim(),
                    LastName = values[7].ToString().Trim(),
                    Balance = decimal.Parse(values[8].ToString()),
                    IsAdmin = (bool)values[9]
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
