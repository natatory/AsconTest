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
using AccountingSystemUI.ViewModel;
using AccountingSystemDAL.Model;
using AccountingSystemDAL.Repos;
using AccountingSystemUI.Application;

namespace AccountingSystemUI.View
{
    /// <summary>
    /// Логика взаимодействия для MoneyManagementWindow.xaml
    /// </summary>
    public partial class MoneyManagementWindow : Window
    {
        MoneyManagementVM mmVM;
        public MoneyManagementWindow(IRepo<Category> categoryRepo, IRepo<Recipient> recipientRepo, IRepo<User> userRepo, IRepo<Data> dataRepo, IWinAccount currentUser)
        {
            mmVM = new MoneyManagementVM(categoryRepo, recipientRepo, userRepo, dataRepo, currentUser);
            this.DataContext = mmVM;
            InitializeComponent();
        }
        public MoneyManagementWindow(IWinAccount currentUser)
        {
            mmVM = new MoneyManagementVM(currentUser);
            this.DataContext = mmVM;
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void dgTransactions_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            if (e.Row.Item is Data)
                txtWarningBalance.Visibility = ((Data)e.Row.Item).BalanceAfterTransact < 0 ?
                    Visibility.Visible : Visibility.Hidden;
        }

    }
}
