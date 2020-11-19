using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using AccountingSystemDAL.Model;


namespace AccountingSystemUI.ViewModel
{
    class DataMultiConverter : IMultiValueConverter
    {
        //Boolean values (validation errors) are expected in the input from Button.CommandParameter.
        //The same array (values) is used to pass user input
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {

            var anyFieldHasError = values.OfType<bool>().Any(e => e == true);
            if (anyFieldHasError) return null;
            else
                try
                {
                    var d = new Data
                    {
                        OpType = (Data.OperationType)values[5],
                        CategoryId = ((Category)values[6]).CategoryId,
                        RecipientId = ((Recipient)values[7]).RecipientId,
                        Description = values[8].ToString(),
                        TransactionAmount = decimal.Parse(values[9].ToString()),
                    };
                    return d;
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
