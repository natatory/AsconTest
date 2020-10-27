using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystemUI.Application
{
    public interface IWinHelper
    {
        IList<IWinAccount> GetWinUsers();

        bool CreateWinAccount(IWinAccount winUser);

        IWinAccount GetCurrentWinAccount();

        IList<string> GetAdministrators();

        IList<string> GetUsers();
    }
}
