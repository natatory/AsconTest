using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystemUI.Application
{
    public interface IDBInteract
    {
        bool IsDBExist(string dbName);

        bool SetAccessRights(string dbName);
    }
}
