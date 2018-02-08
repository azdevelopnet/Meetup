using CouchbaseDemo.Models;
using CouchbaseDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CouchbaseDemo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page2 : ContentPage
	{
		public Page2 ()
		{
			InitializeComponent ();
            BindingContext = AppViewModel.Instance;
            AppViewModel.Instance.LoadPeople();
		}

        public void OnDelete(object sender, EventArgs e)
        {
            MenuItem mi = ((MenuItem)sender);
            Person parameter = (Person)mi.CommandParameter;
            AppViewModel.Instance.DeletePerson(parameter);
            //DisplayAlert("Delete Context Action", $"Delete {parameter.FirstName}", "OK");
        }
    }
}