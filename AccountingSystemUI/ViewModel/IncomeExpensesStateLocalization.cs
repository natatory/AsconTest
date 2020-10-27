using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using AccountingSystemDAL.Model;

namespace AccountingSystemUI.ViewModel
{
    class IncomeExpensesStateLocalization : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Data.OperationType)
                return ((Data.OperationType)value) == Data.OperationType.Расходы ? "Расходы" : "Доходы";
            return null;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
                return ((string)value) == "Доходы" ? Data.OperationType.Доходы
                    : Data.OperationType.Расходы;
            else return null;
        }
    }
}

