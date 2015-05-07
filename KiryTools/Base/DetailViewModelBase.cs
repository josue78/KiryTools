
namespace KiryTools.Base
{
    public abstract class DetailViewModelBase<T> : ViewModelBase
    {

        private T _item;
        public T Item
        {
            get
            {
                return _item;
            }
            set
            {
                SetProperty(ref _item, value);
            }
        }

        protected abstract void GetParam();
        public DetailViewModelBase()
        {
            GetParam();
        }
    }
}
