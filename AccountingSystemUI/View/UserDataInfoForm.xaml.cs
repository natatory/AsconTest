using AccountingSystemDAL.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace AccountingSystemUI.View
{
    /// <summary>
    /// Логика взаимодействия для UserDataInfoForm.xaml
    /// </summary>
    public partial class UserDataInfoForm : Window
    {
        private User _selectedUser;
        public IList<Data> Transactions { get; set; }
        public UserDataInfoForm(User selectedUser)
        {
            _selectedUser = selectedUser;
            Transactions = new ObservableCollection<Data>(_selectedUser.Transactions);
            Title = "Данные пользователя " + _selectedUser.ToString();
            InitializeComponent();
            dgTransactions.ItemsSource = Transactions;

        }
    }
}
