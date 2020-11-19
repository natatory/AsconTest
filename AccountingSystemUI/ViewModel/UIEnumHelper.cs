using System;
using System.Collections.Generic;
using AccountingSystemDAL.Model;
using System.Reflection;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystemUI.ViewModel
{
    public class UIEnumHelper
    {
        public static IEnumerable<string> IncomeExpenseSelections
        {
            get
            {
                var units = new[]
                                {
                                  GetDescription(Data.OperationType.Exspense),
                                  GetDescription(Data.OperationType.Income)
                               };
                return units;
            }
        }

        public static string GetDescription(Enum enumObj)
        {
            FieldInfo fieldInfo =
                enumObj.GetType().GetField(enumObj.ToString());

            object[] attribArray = fieldInfo.GetCustomAttributes(false);

            if (attribArray.Length == 0)
            {
                return enumObj.ToString();
            }
            else
            {
                DescriptionAttribute attrib =
                    attribArray[0] as DescriptionAttribute;
                return attrib.Description;
            }
        }
    }

}
