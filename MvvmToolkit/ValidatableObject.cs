using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MvvmToolkit
{
    public abstract class ValidatableObject : BindableObject, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        [DebuggerHidden]
        public ValidatableObject()
        {
            ErrorsChanged += ValidationBase_ErrorsChanged;
        }

        [DebuggerHidden]
        private void ValidationBase_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            OnPropertyChanged(nameof(HasErrors));
            OnPropertyChanged(nameof(HasNoErrors));
            OnPropertyChanged(nameof(ErrorsList));
        }

        #region INotifyDataErrorInfo Members

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        [DebuggerHidden]
        public IEnumerable GetErrors(string propertyName)
        {
            if (!string.IsNullOrEmpty(propertyName))
            {
                if (_errors.ContainsKey(propertyName) && (_errors[propertyName].Any()))
                {
                    return _errors[propertyName].ToList();
                }
                else
                {
                    return new List<string>();
                }
            }
            else
            {
                return _errors.SelectMany(err => err.Value.ToList()).ToList();
            }
        }

        [DebuggerHidden]
        public bool HasErrors => _errors.Any(propErrors => propErrors.Value.Any());

        public bool HasNoErrors => !HasErrors;

        #endregion

        [DebuggerHidden]
        public virtual void Validate()
        {
            var validationContext = new ValidationContext(this, null);

            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(this, validationContext, validationResults);

            _errors.Clear();

            HandleValidationResults(validationResults);
        }

        [DebuggerHidden]
        protected virtual void ValidateProperty<T>(T value, [CallerMemberName] string propertyName = null)
        {
            var validationContext = new ValidationContext(this, null)
            {
                MemberName = propertyName
            };

            var validationResults = new List<ValidationResult>();
            Validator.TryValidateProperty(value, validationContext, validationResults);

            RemoveErrorsByPropertyName(propertyName);

            HandleValidationResults(validationResults);
        }

        [DebuggerHidden]
        private void RemoveErrorsByPropertyName(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                _errors.Remove(propertyName);
            }

            RaiseErrorsChanged(propertyName);
        }

        [DebuggerHidden]
        private void HandleValidationResults(List<ValidationResult> validationResults)
        {
            IEnumerable<IGrouping<string, ValidationResult>> resultsByPropertyName = from results in validationResults
                                                                                     from memberNames in results.MemberNames
                                                                                     group results by memberNames into groups
                                                                                     select groups;

            foreach (IGrouping<string, ValidationResult> property in resultsByPropertyName)
            {
                _errors.Add(property.Key, property.Select(r => r.ErrorMessage).ToList());
                RaiseErrorsChanged(property.Key);
            }
        }

        [DebuggerHidden]
        private void RaiseErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        [DebuggerHidden]
        public IList<string> ErrorsList => GetErrors(string.Empty).Cast<string>().ToList();
    }
}