using System;
using Prism.Navigation;
using Xamarin.Forms;

namespace PrismDemo
{
    public class PageTwo: ContentPage
    {
        public PageTwo()
        {
            this.Title = "Page Two";

            Content = new StackLayout()
            {
                Margin = 30,
                Children ={
                    new Label(){
                        Text="Page Two Navigation",
                        FontSize =32
                    }
                }
            };
        }

    }
}
