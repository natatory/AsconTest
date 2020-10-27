using System;
using System.Collections.Generic;
using AccountingSystemUI.Cmds;
using System.Windows.Input;
using AccountingSystemDAL.Model;
using AccountingSystemDAL.Repos;
using AccountingSystemUI.Application;
using PropertyChanged;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows;
using AccountingSystemUI.DI;

namespace AccountingSystemUI.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    class AddWinUserFormVM
    {
        IList<IWinAccount> _winUsers;
        private readonly IFactory _factory;
        public bool? DialogResult { get; set; }
        public IWinAccount NewWinUser { get; set; }
        public AddWinUserFormVM(IList<IWinAccount> winUsers, IFactory factory)
        {
            _winUsers = winUsers;
            _factory = factory;
            NewWinUser = CreateNewWinUser();
            CloseAddDialogEventSubscribe();
        }

        //create template for new winuser
        private WinAccount CreateNewWinUser()
        {
            return new WinAccount()
            {
                Name = "Имя",
                IsAdmin = false
            };
        }

        private ICommand _addWinUserCmd = null;
        public ICommand AddWinUserCmd =>
             _addWinUserCmd ?? (_addWinUserCmd = new AddWinUserCommand(_winUsers, _factory));


        private void CloseAddDialogEventSubscribe()
        {
            if (AddWinUserCmd != null)
            {
                ((AddWinUserCommand)AddWinUserCmd).CloseDialog +=
                    (object sender, EventArgs e) => DialogResult = true;
            }
        }
        private void ShowErrorMsg(string msg)
        {
            MessageBox.Show(msg, "Ошибка",
                         MessageBoxButton.OK,
                         MessageBoxImage.Exclamation
                         );
        }
    }
}
