using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystemDAL.Model
{
    public partial class Group
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
                    case nameof(Name):
                        errors = GetErrorsFromAnnotations(nameof(Name), Name);
                        if (errors != null && errors.Length != 0)
                        {
                            AddErrors(nameof(Name), errors);
                            hasError = true;
                        }
                        if (!hasError) ClearErrors(nameof(Name));
                        break;
                }
                return string.Empty;
            }
        }

    }
}
