using Xamarin.Forms;

namespace PrismDemo
{
    public class PageOne : ContentPage
    {
        public PageOne()
        {
            this.Title = "PageOne";
 
            var lbl = new Label()
            {
                Text = "Prism Framework",
                FontSize = 32,
                Margin = new Thickness(30, 20, 30, 30)
            };

            var entryLabel = new Label()
            {
                Text = "Enter Text Field",
                Margin = new Thickness(30, 0, 30, 3)
            };

            var entryField = new Entry()
            {
                Margin = new Thickness(30, 0, 30, 20)
            };
            entryField.SetBinding(Entry.TextProperty, "InputText");

            var bindingLabel = new Label()
            {
                Text = "Two-way binding Label",
                Margin = new Thickness(30, 0, 30, 3)
            };
            var bindingField = new Label()
            {
                Margin = new Thickness(30, 0, 30, 20)
            };
            bindingField.SetBinding(Label.TextProperty, "InputText");

            var btnNavigation = new Button()
            {
                Text = "SAVE",
                Margin = new Thickness(30, 10, 30, 20)
            };
            btnNavigation.SetBinding(Button.CommandProperty, "ChangePages");

            Content = new StackLayout()
            {
                Children =
                {
                    lbl,
                    entryLabel,
                    entryField,
                    bindingLabel,
                    bindingField,
                    btnNavigation
                }
            };
        }
    }
}
