using System.Collections.Generic;
using System.Windows;
using AccountingSystemUI.Application;
using AccountingSystemUI.DI;
using AccountingSystemUI.ViewModel;

namespace AccountingSystemUI.View
{
    /// <summary>
    /// Логика взаимодействия для AddWinUserForm.xaml
    /// </summary>
    public partial class AddWinUserForm : Window
    {
        AddWinUserFormVM addWinUserFormVM;
        public AddWinUserForm(IList<IWinAccount> winUsers, IFactory factory)
        {
            addWinUserFormVM = new AddWinUserFormVM(winUsers, factory);
            this.DataContext = addWinUserFormVM;
            InitializeComponent();
        }
    }
}
