using AccountingSystemDAL.Model;
using AccountingSystemDAL.Repos;
using AccountingSystemUI.View;
using System.Collections.Generic;
using AccountingSystemUI.Application;
using AccountingSystemUI.DI;

namespace AccountingSystemUI.Cmds
{
    class OpenAddWinUserFormCommand : CommandBase
    {
        private IList<IWinAccount> _winUsers;
        private readonly IFactory _factory;
        public OpenAddWinUserFormCommand(IList<IWinAccount> winUsers, IFactory factory)
        {
            _winUsers = winUsers;
            _factory = factory;
        }
        public override bool CanExecute(object parameter)
        {
            return _winUsers != null;
        }

        public override void Execute(object parameter)
        {
            var addWinUserForm = new AddWinUserForm(_winUsers, _factory);
            addWinUserForm.ShowDialog();
        }
    }
}
