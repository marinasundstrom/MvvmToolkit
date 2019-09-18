using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmToolkit
{
    public class Command<T> : ICommand
    {
        private readonly Func<T, Task> _execute;
        private readonly Func<T, bool> _canExecute;

        [DebuggerHidden]
        public Command(Action<T> execute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }

            _execute = (arg) =>
            {
                execute(arg);
                return Task.CompletedTask;
            };
        }

        [DebuggerHidden]
        public Command(Action<T> execute, Func<T, bool> canExecute)
            : this(execute)
        {
            _canExecute = canExecute ?? throw new ArgumentNullException(nameof(canExecute));
        }

        [DebuggerHidden]
        public Command(Func<T, Task> execute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        [DebuggerHidden]
        public Command(Func<T, Task> execute, Func<T, bool> canExecute)
            : this(execute)
        {
            _canExecute = canExecute ?? throw new ArgumentNullException(nameof(canExecute));
        }

        public event EventHandler CanExecuteChanged;

        [DebuggerHidden]
        public Task Execute(T arg)
        {
            return _execute?.Invoke(arg);
        }

        [DebuggerHidden]
        public bool CanExecute(T arg)
        {
            return _canExecute?.Invoke(arg) ?? true;
        }

        [DebuggerHidden]
        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute((T)parameter);
        }

        [DebuggerHidden]
        void ICommand.Execute(object parameter)
        {
            _execute?.Invoke((T)parameter);
        }

        [DebuggerHidden]
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
