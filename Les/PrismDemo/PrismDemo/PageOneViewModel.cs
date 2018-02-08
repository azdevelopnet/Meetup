using System;
using System.Windows.Input;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace PrismDemo
{
    public class PageOneViewModel: BindableBase, INavigationAware
    {
        private string inputText;
        public string InputText{
            get { return inputText; }
            set { SetProperty(ref inputText,value);}
        }

        public ICommand ChangePages { get; set; }

        protected INavigationService _navigationService { get; }

        public PageOneViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            ChangePages = new Command(async(obj) => { 
                await this._navigationService.NavigateAsync("PageTwo");
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            
        }
    }
}
