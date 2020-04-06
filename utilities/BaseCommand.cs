using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace utilities
{
    class BaseCommand : ICommand
    {
        private readonly Predicate<object> _canExecuteMethod = null;
        private readonly Action<object> _executeMethod = null;

        public BaseCommand(Predicate<object> canExecuteMethod, Action<Object> executeMethod)
        {
            _canExecuteMethod = canExecuteMethod ?? throw new ArgumentNullException(nameof(canExecuteMethod));
            _executeMethod = executeMethod ?? throw new ArgumentNullException(nameof(executeMethod));
        }

        public bool CanExecute(object parameter)
        {
            return _canExecuteMethod.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            _executeMethod.Invoke(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }
}
