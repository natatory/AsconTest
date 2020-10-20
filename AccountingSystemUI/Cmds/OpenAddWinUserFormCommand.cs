using AccountingSystemDAL.Model;
using AccountingSystemDAL.Repos;
using AccountingSystemUI.View;
using System.Collections.Generic;
using AccountingSystemUI.Application;

namespace AccountingSystemUI.Cmds
{
    class OpenAddWinUserFormCommand :CommandBase
    {
        private IList<IWinAccount> _winUsers;
        public OpenAddWinUserFormCommand(IList<IWinAccount> winUsers)
        {
            _winUsers = winUsers;
        }
        public override bool CanExecute(object parameter)
        {
            return _winUsers != null;
        }

        public override void Execute(object parameter)
        {
            var addWinUserForm = new AddWinUserForm(_winUsers);
            addWinUserForm.ShowDialog();
        }
    }
}
