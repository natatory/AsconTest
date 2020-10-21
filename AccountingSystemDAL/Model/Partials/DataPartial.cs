
namespace AccountingSystemDAL.Model
{
    public partial class Data
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
                    case nameof(Description):
                        errors = GetErrorsFromAnnotations(nameof(Description), Description);
                        if (errors != null && errors.Length != 0)
                        {
                            AddErrors(nameof(Description), errors);
                            hasError = true;
                        }
                        if (!hasError) ClearErrors(nameof(Description));
                        break;
                    case nameof(TransactionAmount):
                        if (!CheckTransactionAmountFieldRule(TransactionAmount))
                        {
                            hasError = true;
                            AddError(nameof(TransactionAmount),
                                         $"Введите сумму больше нуля");
                        }
                        errors = GetErrorsFromAnnotations(nameof(TransactionAmount), TransactionAmount);
                        if (errors != null && errors.Length != 0)
                        {
                            AddErrors(nameof(TransactionAmount), errors);
                            hasError = true;
                        }
                        if (!hasError) ClearErrors(nameof(TransactionAmount));
                        break;
                    case nameof(Category):
                        errors = GetErrorsFromAnnotations(nameof(Category), Category);
                        if (errors != null && errors.Length != 0)
                        {
                            AddErrors(nameof(Category), errors);
                            hasError = true;
                        }
                        if (!hasError) ClearErrors(nameof(Category));
                        break;
                    case nameof(OpType):
                        errors = GetErrorsFromAnnotations(nameof(OpType), OpType);
                        if (errors != null && errors.Length != 0)
                        {
                            AddErrors(nameof(OpType), errors);
                            hasError = true;
                        }
                        if (!hasError) ClearErrors(nameof(OpType));
                        break;
                    case nameof(Recipient):
                        errors = GetErrorsFromAnnotations(nameof(Recipient), Recipient);
                        if (errors != null && errors.Length != 0)
                        {
                            AddErrors(nameof(Recipient), errors);
                            hasError = true;
                        }
                        if (!hasError) ClearErrors(nameof(Recipient));
                        break;
                }
                return string.Empty;
            }
        }
        private bool CheckTransactionAmountFieldRule(decimal field) => field > 0;
    }
}