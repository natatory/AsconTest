using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AccSysUI.ViewModel;
using AccountingSystemDAL.Model;
using AccountingSystemDAL.Repos;

namespace AccSysUI.View
{
    /// <summary>
    /// Логика взаимодействия для MoneyManagementWindow.xaml
    /// </summary>
    public partial class MoneyManagementWindow : Window
    {
        MoneyManagementVM mmVM;
        List<string> combo = new List<string>() { "коммунальные платежи", "программа", "программа", "программа", "программа" };
        public MoneyManagementWindow(IRepo<Category> categoryRepo)
        {
            mmVM = new MoneyManagementVM(categoryRepo);
            this.DataContext = mmVM;
            InitializeComponent();
            cbCategory.ItemsSource = combo;
            cbOpType.ItemsSource = Enum.GetValues(typeof(Data.OperationType))
                .OfType<Data.OperationType>();
        }
    }
}
