using AccountingSystemDAL.Model;
using AccountingSystemDAL.Repos;
using AccountingSystemUI.DI;
using AccountingSystemUI.View;
using System.Collections.Generic;

namespace AccountingSystemUI.Cmds
{
    public class OpenUserManagementFormCommand : CommandBase
    {
        private IList<User> _users;
        private IRepo<User> _userRepo;
        private readonly IFactory _factory;
        public OpenUserManagementFormCommand(IFactory factory)
        {
            _factory = factory;
            _users = _factory.CreateUserObservableCollection();
            _userRepo = _factory.CreateUserRepo();
        }
        public override bool CanExecute(object parameter)
        {
            return _users != null && _userRepo != null;
        }

        public override void Execute(object parameter)
        {
            var addUserForm = new AddUserForm(_factory);
            addUserForm.ShowDialog();
        }
    }
}
