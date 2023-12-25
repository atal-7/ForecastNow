using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ForecastNow.ViewModel.Base
{
    public class CommandBase : ICommand
    {

        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public CommandBase(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public CommandBase(Action<object> execute) : this(execute, null) { }

        public bool CanExecute(object? parameter)
        {
            if (_canExecute == null)
                return true;
            return _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            if (_execute != null)
                _execute(parameter);
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
