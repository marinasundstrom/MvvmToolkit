using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MvvmToolkit
{
    public abstract class BindableObject : INotifyPropertyChanged
    {
        [DebuggerHidden]
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [DebuggerHidden]
        protected virtual bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, newValue))
            {
                return false;
            }

            field = newValue;
            OnPropertyChanged(propertyName);

            return true;
        }

        [DebuggerHidden]
        protected virtual bool SetProperty<T>(ref IEnumerable<T> field, IEnumerable<T> newValue, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, newValue))
            {
                return false;
            }

            field = newValue;
            OnPropertyChanged(propertyName);

            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
