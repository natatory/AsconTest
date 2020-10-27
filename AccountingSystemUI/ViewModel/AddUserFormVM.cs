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
    class AddUserFormVM
    {
        public IList<User> Users { get; set; }
        public IList<IWinAccount> WinUsers { get; set; }
        public bool? DialogResult { get; set; }
        public User NewUser { get; set; }
        private readonly IFactory _factory;
        public AddUserFormVM(IFactory factory)
        {
            _factory = factory;
            Users = _factory.CreateUserObservableCollection();
            WinUsers = GetWinAccounts();
            NewUser = GetNewUser();
        }
        //generate a part of a new User entity,  
        //this will be send to the form as some initial data fields
        //to allow Model Validation-based check input
        private User GetNewUser()
        {
            return new User()
            {
                FirstName = "Имя",
                LastName = "Фамилия",
                Balance = 100m,
            };
        }

        private IList<IWinAccount> GetWinAccounts()
        {
            try
            {
                return new ObservableCollection<IWinAccount>(_factory.CreateWinHelper().GetWinUsers());
            }
            catch (Exception ex)
            {
                ShowErrorMsg(ex.Message);
                return null;
            }
        }
        private ICommand _addUserCmd = null;
        public ICommand AddUserCmd =>
             _addUserCmd ?? (_addUserCmd = new AddUserCommand(_factory));

        private ICommand _openAddWinUserFormCmd = null;
        public ICommand OpenAddWinUserFormCmd =>
             _openAddWinUserFormCmd ?? (_openAddWinUserFormCmd = new OpenAddWinUserFormCommand(WinUsers));

        private void CloseAddDialogEventSubscribe()
        {
            if (AddUserCmd != null)
            {
                ((AddUserCommand)AddUserCmd).CloseDialog +=
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
