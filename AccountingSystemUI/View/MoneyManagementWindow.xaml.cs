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
            IsEnabled = mmVM.IsFormEnable;
            this.DataContext = mmVM;
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
