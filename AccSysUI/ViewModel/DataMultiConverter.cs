using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using AccountingSystemDAL.Model;


namespace AccSysUI.ViewModel
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
                    return new Data
                    {
                        DataId = Guid.NewGuid(),
                        OpType = (Data.OperationType)values[5],
                        CategoryId = ((Category)values[6]).CategoryId,
                        Description = values[7].ToString(),
                        RecipientId = ((Recipient)values[8]).RecipientId,
                        TransactionAmount = decimal.Parse(values[9].ToString())
                    };
                }
                catch(Exception ex)
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
