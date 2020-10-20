using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystemDAL.Model
{
    public partial class User
    {
        //implement IDataErrorInfo for Validation
        public override string this[string columnName]
        {
            get
            {
                string[] errors;
                bool hasError = false;
                switch (columnName)
                {
                    case nameof(FirstName):
                        errors = GetErrorsFromAnnotations(nameof(FirstName), FirstName);
                        if (errors != null && errors.Length != 0)
                        {
                            AddErrors(nameof(FirstName), errors);
                            hasError = true;
                        }
                        if (!hasError) ClearErrors(nameof(FirstName));
                        break;
                    case nameof(LastName):
                        errors = GetErrorsFromAnnotations(nameof(LastName), LastName);
                        if (errors != null && errors.Length != 0)
                        {
                            AddErrors(nameof(LastName), errors);
                            hasError = true;
                        }
                        if (!hasError) ClearErrors(nameof(LastName));
                        break;
                    case nameof(Balance):
                        errors = GetErrorsFromAnnotations(nameof(Balance), Balance);
                        if (errors != null && errors.Length != 0)
                        {
                            AddErrors(nameof(Balance), errors);
                            hasError = true;
                        }
                        if (!hasError) ClearErrors(nameof(Balance));
                        break;
                    case nameof(WinUserName):
                        errors = GetErrorsFromAnnotations(nameof(WinUserName), WinUserName);
                        if (errors != null && errors.Length != 0)
                        {
                            AddErrors(nameof(WinUserName), errors);
                            hasError = true;
                        }
                        if (!hasError) ClearErrors(nameof(WinUserName));
                        break;
                }
                return string.Empty;
            }
        }
    }
}
