﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingSystemDAL.Model;
using System.Data;
using AccountingSystemUI.Application;


namespace AccountingSystemUI.Cmds
{
    public class ExcelExportCommand : CommandBase
    {
        public override bool CanExecute(object parameter)
        {
            return (parameter as User) != null
                && (parameter as User).Transactions != null;
        }

        public override void Execute(object parameter)
        {
            var currentUser = parameter as User;
            var transactions = ExstractTargetFieldsFromData(currentUser.Transactions.ToList());
            Task.Run(() => ExcelExporter.ExportToFile(currentUser.ToString(), transactions));
        }
        private List<DataForExport> ExstractTargetFieldsFromData(IList<Data> listData)
        {
            var result = new List<DataForExport>();
            foreach (var d in listData)
            {
                result.Add(new DataForExport
                {
                    Category = d.Category.ToString(),
                    OpType = d.OpType == Data.OperationType.Доходы ? "Доходы" : "Расходы",
                    Description = d.Description.ToString(),
                    Recipient = d.Recipient.ToString(),
                    TransactionAmount = d.TransactionAmount.ToString(),
                    BalanceAfterTransact = d.BalanceAfterTransact.ToString(),
                    Date = d.Date.ToString()
                });
            }
            return result;
        }
    }
}
