
using System;
using Xamarin.Forms;
using Xamarin.Forms.CommonCore;

namespace firebaseDemo.Views {
    
    public class PageTwoCell : ViewCell{
        private Label lblName;
        private Label lblSquadName;

        public PageTwoCell() {
            lblName = new Label() {
                FontSize = 16
            };

            lblSquadName = new Label() {
                FontSize = 14,
                TextColor = Color.Gray
            };

            View = new StackLayout() {
                Padding = new Thickness(10, 5, 0, 5),
                Children = { lblName, lblSquadName }
            };

            base.OnBindingContextChanged();
        }
    }
}
