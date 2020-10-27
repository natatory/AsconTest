using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystemUI.Application
{
    public interface IDataForExport
    {
        string TransactionAmount { get; set; }
        string Description { get; set; }
        string OpType { get; set; }
        string OperationType { get; set; }
        string Date { get; set; }
        string BalanceAfterTransact { get; set; }
        string Category { get; set; }
        string Recipient { get; set; }
    }
}
