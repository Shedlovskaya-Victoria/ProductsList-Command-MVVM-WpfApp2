using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProductsList_Command_MVVM_WpfApp2.mvvm
{
    public class Command : ICommand
    {
        public event EventHandler? CanExecuteChanged {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        Action action;
        Func<bool> canExecute;

        public Command(Action action, Func<bool> func = null)
        {
            this.action = action;
            this.canExecute = func;
        }

        public bool CanExecute(object? parameter)
        {
            return canExecute?.Invoke() ?? true;
        }

        public void Execute(object? parameter) => action();
    }
}
