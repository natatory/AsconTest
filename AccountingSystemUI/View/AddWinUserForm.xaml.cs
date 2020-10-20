using System.Collections.Generic;
using System.Windows;
using AccountingSystemUI.Application;
using AccountingSystemUI.ViewModel;

namespace AccountingSystemUI.View
{
    /// <summary>
    /// Логика взаимодействия для AddWinUserForm.xaml
    /// </summary>
    public partial class AddWinUserForm : Window
    {
        AddWinUserFormVM addWinUserFormVM;
        IList<IWinAccount> _winUsers;
        public AddWinUserForm(IList<IWinAccount> winUsers)
        {
            _winUsers = winUsers;
            addWinUserFormVM = new AddWinUserFormVM(_winUsers);
            this.DataContext = addWinUserFormVM;
            InitializeComponent();
        }
    }
}
