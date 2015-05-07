using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using KiryTools.Other;

namespace KiryTools.Base
{
    public abstract class ListViewModelBase<T> : ViewModelBase
    {
        protected abstract void SetParameter(object param);
        protected abstract Task LoadAsync();
        private ObservableCollection<T> _items;
        public ObservableCollection<T> Items
        {
            get
            {
                return _items;
            }
            set
            {
                SetProperty(ref _items, value);
            }
        }
        public ICommand LoadCommand { get; set; }
        public ICommand SelectCommand { get; set; }

        protected ListViewModelBase()
        {
            SelectCommand=new Command<T>(item=>SetParameter(item));
            LoadCommand=new AsyncCommand(LoadAsync);
        }
    }
}
