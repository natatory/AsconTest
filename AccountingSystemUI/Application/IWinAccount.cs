using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystemUI.Application
{
    public interface IWinAccount
    {
        string Name { get; set; }
        bool IsAdmin { get; set; }
        string ToString();
    }
}
