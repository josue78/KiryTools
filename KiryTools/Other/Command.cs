using System;
using System.Windows.Input;

namespace KiryTools.Other
{
    public class Command : ICommand
    {
        private readonly Action _action;

        public Command(Action action)
        {
            _action = action;
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs());
        }
        public bool CanExecute(object parameter)
        {

            return _action != null;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (_action == null) return;
            _action();
        }
    }

    public class Command<T> : ICommand
    {

        private readonly Action<T> _action;

        public Command(Action<T> action)
        {
            _action = action;
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs());
        }
        public bool CanExecute(object parameter)
        {

            return _action != null;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
      
                _action((T)parameter);
        }
    }
}
