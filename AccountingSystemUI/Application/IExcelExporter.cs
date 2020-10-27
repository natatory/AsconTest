using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystemUI.Application
{
    public interface IExcelExporter
    {
        void ExportToFile(string name, IList<IDataForExport> listToExport);
    }
}
