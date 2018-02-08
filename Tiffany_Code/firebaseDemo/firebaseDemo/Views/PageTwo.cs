using System;
using firebaseDemo.Models;
using firebaseDemo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.CommonCore;

namespace firebaseDemo.Views {
    public class PageTwo : BoundPage<AppViewModel> {


		public PageTwo() {
            var lst = new ListView() {
                ItemTemplate = new DataTemplate(typeof(PageTwoCell))
            };

            lst.SetBinding(ListView.ItemsSourceProperty, "StormTroopers");

            Content = new StackLayout() {
                Children = { lst }
            };

        }
    }
}
