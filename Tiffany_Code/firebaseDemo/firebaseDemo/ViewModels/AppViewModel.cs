using System;
using System.Windows.Input;
using Xamarin.Forms.CommonCore;
using System.Linq;
using System.Collections.ObjectModel;
using firebaseDemo.Config;
using System.Collections.Generic;
using firebaseDemo.Models;
using Newtonsoft.Json;
using firebaseDemo.Views;

namespace firebaseDemo.ViewModels {
    public class AppViewModel : ObservableViewModel {

        public ICommand ViewStormTroopers { get; set; }
        public Dictionary<string, StormTroopers> stormtroopers { get; set; }

        //public Dictionary<string, StormTroopers> StormTroopers {
        //    get { return stormtroopers ?? (stormtroopers = new Dictionary<string, StormTroopers>()); }
        //    set { SetProperty(ref stormtroopers, value );}
        //}
        // public async void sendRequest() {
            
        // values = JsonConvert.DeserializeObject<Dictionary<string, string>>(cleanResponse);
		//}

        public async void setRequest(string stmTroop, string squad) {

                FireBaseClient fbc = new FireBaseClient();

                var newStormTrooper = new StormTroopers() {
                    stormTroopName = stmTroop,
                    stormTroopSquad = squad
                };

                StormTroopers response = await fbc.AddTrooper("stormtroopers/", newStormTrooper);
        }

		public AppViewModel() {

			ViewStormTroopers = new RelayCommand(async (obj) => {
				FireBaseClient fbc = new FireBaseClient();
				Dictionary<string, string> values = new Dictionary<string, string>();

				var response = await fbc.Get("stormtroopers/");

				var cleanResponse = response.Replace(@"\", string.Empty)
						.Replace(@"-", string.Empty)
						.Replace(@".", string.Empty);
                // firebaseLookup = JsonConvert.DeserializeObject<Dictionary<string, StormTroopers>>(json);
               // StormTroopers
                //await Navigation.PushAsync(new PageTwo());

			});
		}
    }
}