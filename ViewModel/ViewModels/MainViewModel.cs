using KiryTools.Base;
using ViewModel.Models;

namespace ViewModel.ViewModels
{
   public class MainViewModel:ViewModelBase
    {
       private readonly Hello _hello=new Hello();

        public string Greeting
        {
            get
            {
                return Hello.Greeting(Name);
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                SetProperty(ref _name, value);
                NotifyChanges(Greeting);
            }
        }
        
        
    }
}
