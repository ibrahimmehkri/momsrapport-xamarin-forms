using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace MomsRapportApp.Validations
{
    public class ValidatableObject<T> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<IValidationRule<T>> Validations { get; set; }
        public List<string> Errors { get; set; }

        private bool _isValid;
        public bool IsValid
        {
            get { return _isValid; }
            set
            {
                _isValid = value;
                OnPropertyChanged("IsValid");
            }
        }

        private T _value;
        public T Value
        {
            get { return _value; }
            set
            {
                _value = value;
                bool check = Validate();
                OnPropertyChanged("Value");
                Debug.WriteLine(check);
            }
        }

        public ValidatableObject()
        {
            Validations = new List<IValidationRule<T>>();
            Errors = new List<string>();
        }

        public bool Validate()
        {
            Errors.Clear();

            foreach (var item in Validations)
            {
                if (!(item.Check(Value)))
                {
                    Errors.Add(item.Message);
                }
            }
            IsValid = Errors.Count == 0;
            return IsValid;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
