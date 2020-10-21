
namespace AccountingSystemDAL.Model
{
    public partial class Recipient
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
