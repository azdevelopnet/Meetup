using System;
using System.Collections.ObjectModel;
using System.Linq;
using firebaseDemo.Models;
using firebaseDemo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.CommonCore;
using firebaseDemo.Config;
using FireSharp;

namespace firebaseDemo.Views {


    public class PageOne : BoundPage<AppViewModel> {

        Image stormTroop;
        Label fireBaseLbl;
        Label nameYourTrooperLbl;
        Entry trooperNameEntry;
        Label trooperSquadLbl;
        Entry trooperSquadEntry;
        Button postBtn;
        Button getDataBtn;

        public PageOne() {

            stormTroop = new Image() {
                Aspect = Aspect.AspectFit
            };

            stormTroop.Source = ImageSource.FromFile("stormTroop.png");

            fireBaseLbl = new Label() {
                Text = "Firebase Tutorial",
                FontSize = 24,
                HorizontalOptions = LayoutOptions.Center
            };

            nameYourTrooperLbl = new Label() {
                Text = "Name your trooper",
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Start
            };

            trooperNameEntry = new Entry() {
                Placeholder = "FIN",
                WidthRequest = 200
            };

            trooperSquadLbl = new Label() {
                Text = "Trooper Squad",
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Start
            };

            trooperSquadEntry = new Entry() {
                Placeholder = "501st Legion",
                WidthRequest = 200
            };

            postBtn = new Button() {
                Text = "Add to Squad",
                FontSize = 18    
            };
            postBtn.Clicked += postBtnClicked;

            getDataBtn = new Button() {
                Text = "View Squad",
                FontSize = 18
            };
            getDataBtn.SetBinding(Button.CommandProperty, "ViewStormTroopers");


			// Make a mention of how this changed Device.OS
			switch (Device.RuntimePlatform) {
                case Device.iOS:
                    fireBaseLbl.FontFamily = "Fjalla One";
                    nameYourTrooperLbl.FontFamily = "Fjalla One";
                    trooperSquadLbl.FontFamily = "Fjalla One";
                    break;

                case Device.Android:
                    fireBaseLbl.FontFamily = "FjallaOne-Regular.ttf#FjallaOne-Regular";
                    nameYourTrooperLbl.FontFamily = "FjallaOne - Regular.ttf#FjallaOne-Regular";
                    trooperSquadLbl.FontFamily = "FjallaOne-Regular.ttf#FjallaOne-Regular";
					break;
            };



            Content = new StackLayout {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = 25,
                Spacing = 15,
                Children = {
                    stormTroop,
                    fireBaseLbl,
                            new StackLayout {
                                    Orientation = StackOrientation.Horizontal,
                                    Margin = new Thickness(15, 5),
                                    Children = {
                                        nameYourTrooperLbl,
                                        trooperNameEntry
                                    }
                                },
                            new StackLayout {
                                Orientation = StackOrientation.Horizontal,
                                Margin = new Thickness(15, 5),
                                Children = {
                                    trooperSquadLbl,
                                    trooperSquadEntry
                                }
                            },

                            postBtn,
                            getDataBtn,
                }

            };

        }

		void postBtnClicked(object sender, EventArgs e) {
			string stormtroopy = this.trooperNameEntry.Text;
			string squadNum = this.trooperSquadEntry.Text;
			VM.setRequest(stormtroopy, squadNum);
		}

		//void getDataBtnClicked(object sender, EventArgs e) {
		//	VM.sendRequest();
		//	//async Navigation.PushAsync(new PageTwo());
		//}
    }
};
