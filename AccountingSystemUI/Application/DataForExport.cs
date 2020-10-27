using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystemUI.Application
{
    public class DataForExport //: IDataForExport
    {
        public string TransactionAmount { get; set; }
        public string Description { get; set; }
        public string OpType { get; set; }
        public string OperationType { get; set; }
        public string Date { get; set; }
        public string BalanceAfterTransact { get; set; }
        public string Category { get; set; }
        public string Recipient { get; set; }
    }
}
