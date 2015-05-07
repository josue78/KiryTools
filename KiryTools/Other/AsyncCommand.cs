using System;
using System.Threading.Tasks;
using System.Windows.Input;
using KiryTools.Base;

namespace KiryTools.Other
{
    public class AsyncCommandParameter<T> : ICommand
    {
        private readonly Func<T, Task> _functionT;
        public AsyncCommandParameter(Func<T, Task> function)
        {
            _functionT = function;
            if (CanExecuteChanged == null) return;
            CanExecuteChanged(this, new EventArgs());
        }
        public bool CanExecute(object parameter)
        {
            return _functionT != null;
        }

        public event EventHandler CanExecuteChanged;

        public async void Execute(object parameter)
        {
            if (_functionT == null) return;
            await _functionT((T)parameter);
        }
    }
    public class AsyncCommand<T> : ICommand
    {
        private readonly Func<Task<T>> _function;
        private readonly ViewModelBase _viewModel;
        public AsyncCommand(Func<Task<T>> function, ViewModelBase viewModelBase = null)
        {
            _function = function;
            _viewModel = viewModelBase;
            if (CanExecuteChanged == null) return;
            CanExecuteChanged(this, new EventArgs());
        }
        public bool CanExecute(object parameter)
        {
            return _function!=null;
        }

        private void StartLoad()
        {
            if (_viewModel == null) return;
            _viewModel.Loading = true;
        }
        private void EndLoad()
        {
            if (_viewModel == null) return;
            _viewModel.Loading = false;
        }
        public event EventHandler CanExecuteChanged;

        public async void Execute(object parameter)
        {
            if (_function == null) return;
            StartLoad();
            await _function();
            EndLoad();
        }
    }
    public class AsyncCommand : ICommand
    {
        private readonly ViewModelBase _viewModel;
        private readonly Func<Task> _function;
        private bool _isWorking;
        public AsyncCommand(Func<Task> function, ViewModelBase viewModel = null)
        {
            _function = function;
            _viewModel = viewModel;
            if (CanExecuteChanged == null) return;
            CanExecuteChanged(this, new EventArgs());
        }

        public bool CanExecute(object parameter)
        {
            return _function != null && !_isWorking;

        }


        private void StartLoad()
        {
            _isWorking = true;
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs());
            if (_viewModel == null) return;
            _viewModel.Loading = true;
        }
        private void EndLoad()
        {
            _isWorking = false;
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs());
            if (_viewModel == null) return;
            _viewModel.Loading = false;
        }
        public event EventHandler CanExecuteChanged;

        public async void Execute(object parameter)
        {

            if (_function == null) return;
            StartLoad();
            try
            {
                await _function();
            }
            catch (Exception)
            {
            
            }
            EndLoad();
        }
    }
}
