using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using firebaseDemo.Models;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace firebaseDemo.Config {
    public class FireBaseClient {
        
        private const string BasePath = "https://fir-demo-2d2df.firebaseio.com/";
        private const string FirebaseSecret = "2w4C0JXQVK3k0Lnx7T1jmyjnpYqtB1AluBCz7YIA";

        public FireBaseClient() {
            FireBaseConnect();
        }

        IFirebaseConfig config = new FirebaseConfig {
                AuthSecret = FirebaseSecret,
                BasePath = BasePath
            };

        IFirebaseClient client;

            public void FireBaseConnect() {
                client = new FirebaseClient(config);
            }

        public async Task<string> Get(string path) {
            FirebaseResponse response = await client.GetAsync(path);
            return response.Body;
        }

        public async Task<StormTroopers> GetTrooper(string path) {
            FirebaseResponse response = await client.GetAsync(path);
            StormTroopers trooper = response.ResultAs<StormTroopers>();
            return trooper;
        }

        public async Task<StormTroopers> AddTrooper(string path, StormTroopers model) {
            PushResponse response = await client.PushAsync(path, model);
            StormTroopers trooper = response.ResultAs<StormTroopers>();
            return trooper;
        }

        public async void Update(string path, string key, string value) {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add(key, value);
            FirebaseResponse response = await client.UpdateAsync(path, values);
        }
  

        }
    }
