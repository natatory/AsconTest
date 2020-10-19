using System;
using System.Collections.Generic;
using AccountingSystemUI.Cmds;
using System.Windows.Input;
using AccountingSystemDAL.Model;
using AccountingSystemDAL.Repos;
using AccountingSystemUI.Application;
using PropertyChanged;
using System.Linq;

namespace AccountingSystemUI.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    class AddUserFormVM
    {
        public IRepo<User> _userRepo;
        public IList<User> Users { get; set; }
        public IList<WinAccount> WinUsers { get; set; }
        public bool? DialogResult { get; set; }
        public AddUserFormVM(IRepo<User> userRepo, IList<User> users)
        {
            _userRepo = userRepo;
            Users = users;
            WinUsers = GetWinAccounts();
        }

        private User GetNewUser()
        {
            return new User()
            {
                UserId = Guid.NewGuid(),
                FirstName = "Имя",
                LastName = "Фамилия",
                 
            };
        }
        private ICommand _addUserCmd = null;
        public ICommand AddUserCmd =>

             _addUserCmd ?? (_addUserCmd = new AddUserCommand(_userRepo, Users));
        private void CloseAddDialogEventSubscribe()
        {
            if (AddUserCmd != null)
            {
                ((AddUserCommand)AddUserCmd).CloseDialog +=
                    (object sender, EventArgs e) => DialogResult = true;
            }
        }

    }
}
