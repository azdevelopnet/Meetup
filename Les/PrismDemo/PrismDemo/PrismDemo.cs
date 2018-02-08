using System;
using Prism;
using Prism.Ioc;
using Prism.Navigation;
using Prism.Unity;
using Xamarin.Forms;

namespace PrismDemo
{

    public class App : PrismApplication
    {
        public INavigationService Nav { get; set; }
        public App(IPlatformInitializer initializer = null) 
            : base (initializer) 
        {
            Nav = this.NavigationService;
        }

        protected override void OnInitialized()
        {
            NavigationService.NavigateAsync("Navigation/PageOne");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>("Navigation");
            containerRegistry.RegisterForNavigation<PageOne>("PageOne");
            containerRegistry.RegisterForNavigation<PageTwo>("PageTwo");



        }

    }
}
