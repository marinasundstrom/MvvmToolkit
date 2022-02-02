using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmToolkit
{
    public class Command : ICommand
    {
        private readonly Func<Task> _execute;
        private readonly Func<bool> _canExecute;

        [DebuggerHidden]
        public Command(Func<Task> execute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        [DebuggerHidden]
        public Command(Func<Task> execute, Func<bool> canExecute)
            : this(execute)
        {
            _canExecute = canExecute ?? throw new ArgumentNullException(nameof(canExecute));
        }

        [DebuggerHidden]
        public Command(Action execute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }

            _execute = () =>
            {
                execute();
                return Task.CompletedTask;
            };
        }

        [DebuggerHidden]
        public Command(Action execute, Func<bool> canExecute)
            : this(execute)
        {
            _canExecute = canExecute ?? throw new ArgumentNullException(nameof(canExecute));
        }

        public event EventHandler CanExecuteChanged;

        [DebuggerHidden]
        public Task Execute()
        {
            return _execute?.Invoke();
        }

        [DebuggerHidden]
        public bool CanExecute()
        {
            return _canExecute?.Invoke() ?? true;
        }

        [DebuggerHidden]
        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }

        [DebuggerHidden]
        void ICommand.Execute(object parameter)
        {
            _execute?.Invoke();
        }

        [DebuggerHidden]
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}