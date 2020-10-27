using System;
using System.Collections.Generic;
using ClosedXML.Excel;
using AccountingSystemUI.Application;
using System.Windows;


namespace AccountingSystemUI.Cmds
{
    public class ExcelExporter : IExcelExporter
    {
        public void ExportToFile(string name, IList<DataForExport> listToExport)
        {
            if (listToExport == null || string.IsNullOrEmpty(name)) return;
            using (var workbook = new XLWorkbook())
            {
                try
                {
                    var tableOfData = IEnumerableToDataTable.ToDataTable(listToExport);
                        workbook.Worksheets.Add(tableOfData, $"Транзакции_{name}");
                    var file = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $"\\Отчет_{name}.xlsx";
                        workbook.SaveAs(file);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MessageBox.Show($"Отчет сохранен в папке {Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\n\n" +
                    $"Файл Отчет_{name}.xlsx");
            }
        }
       
    }
}
