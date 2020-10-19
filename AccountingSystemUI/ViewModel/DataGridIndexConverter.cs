using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Controls;


namespace AccountingSystemUI.ViewModel
{
    public class IndexConverter : IValueConverter
    {
        public object Convert(object value, Type TargetType, object parameter, CultureInfo culture)
        {
            var item = (DataGridRow)value;
            var datgrid = ItemsControl.ItemsControlFromItemContainer(item) as DataGrid;
            int index = datgrid.ItemContainerGenerator.IndexFromContainer(item) + 1;
            return index.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
