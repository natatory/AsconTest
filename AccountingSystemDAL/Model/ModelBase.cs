using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using PropertyChanged;

namespace AccountingSystemDAL.Model
{
    [AddINotifyPropertyChangedInterface]
    public abstract class ModelBase : IDataErrorInfo, INotifyDataErrorInfo
    {
        [Timestamp]
        public byte[] Timestamp { get; set; }

        public abstract string this[string columnName]
        {
            get;
        }

        private readonly Dictionary<string, List<string>> Errors = new Dictionary<string, List<string>>();

        //IDataErrorInfo
        public string Error { get; }

        //INotifyDataErrorInfo
        public bool HasErrors => Errors.Count != 0;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return Errors.Values;
            }
            return Errors.ContainsKey(propertyName) ? Errors[propertyName] : null; ;
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        protected void ClearErrors(string propertyName = "")
        {
            Errors.Remove(propertyName);
            OnErrorsChanged(propertyName);
        }

        protected void AddError(string propertyName, string error)
        {
            AddErrors(propertyName, new List<string> { error });
        }

        protected void AddErrors(string propertyName, IList<string> errors)
        {
            var changed = false;
            if (!Errors.ContainsKey(propertyName))
            {
                Errors.Add(propertyName, new List<string>());
                changed = true;
            }
            errors.ToList().ForEach(x =>
            {
                if (Errors[propertyName].Contains(x)) return;
                Errors[propertyName].Add(x);
                changed = true;
            });
            if (changed)
            {
                OnErrorsChanged(propertyName);
            }
        }

        protected string[] GetErrorsFromAnnotations<T>(string propertyName, T value)
        {
            var results = new List<ValidationResult>();
            var vc = new ValidationContext(this, null, null) { MemberName = propertyName };
            var isValid = Validator.TryValidateProperty(value, vc, results);
            return (isValid) ? null : Array.ConvertAll(results.ToArray(), o => o.ErrorMessage);
        }
    }
}
