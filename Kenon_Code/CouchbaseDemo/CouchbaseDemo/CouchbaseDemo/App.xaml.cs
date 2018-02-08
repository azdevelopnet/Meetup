using Couchbase.Lite;
using CouchbaseDemo.ViewModels;
using CouchbaseDemo.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CouchbaseDemo
{
	public partial class App : Application
	{
        public static INavigation Navigation { get; set; }
        public static Database CouchBaseInstance { get; set; }
		public App ()
		{
			InitializeComponent();

            Page1 startPage = new Page1();
            App.Navigation = startPage.Navigation;
            MainPage = new NavigationPage(startPage);
		}

		protected override void OnStart ()
		{
            // Couchbase setup stuff
#if __IOS__
            Couchbase.Lite.Storage.SystemSQLite.Plugin.Register();
#else
            Couchbase.Lite.Storage.CustomSQLite.Plugin.Register();
#endif
            Manager manager = Manager.SharedInstance;

            Database database = manager.GetDatabase("app");
            App.CouchBaseInstance = database;
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

        
	}
}
