using AccountingSystemDAL.Model;
using AccountingSystemDAL.Repos;
using AccountingSystemUI.View;
using System.Collections.Generic;

namespace AccountingSystemUI.Cmds
{
    public class OpenUserManagementFormCommand : CommandBase
    {
        private IList<User> _users;
        private IRepo<User> _userRepo;
        public OpenUserManagementFormCommand(IList<User> users, IRepo<User> userRepo)
        {
            _users = users;
            _userRepo = userRepo;
        }
        public override bool CanExecute(object parameter)
        {
            return _users != null && _userRepo != null;
        }

        public override void Execute(object parameter)
        {
            var addUserForm = new AddUserForm(_userRepo, _users);
            addUserForm.ShowDialog();
        }
    }
}
