using Couchbase.Lite;
using CouchbaseDemo.Models;
using CouchbaseDemo.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Couchbase.Lite;
using System.Collections.ObjectModel;
using System.Linq;

namespace CouchbaseDemo.ViewModels
{
    public class AppViewModel : BindableObject
    {
        //Make this class a singleton.  Not exactly the way you'd want to do it in Production (as it may not handle backgrounding states well), but good enough for this demo   
        private static AppViewModel instance;
        public static AppViewModel Instance
        {
            get
            {
                return instance ?? (instance = new AppViewModel());
            }
        }

        private Person newPerson;
        public Person NewPerson
        {
            get { return newPerson ?? (newPerson = new Person()); }
            set
            {
                newPerson = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Person> people;
        public ObservableCollection<Person> People
        {
            get { return people ?? (people = new ObservableCollection<Person>()); }
            set
            {
                People = value;
                OnPropertyChanged();
            }
        }

        public Command AddPerson { get; set; }
        public Command ViewPeople { get; set; }
        private AppViewModel()
        {
            AddPerson = new Command(AddPersonImplementation);
            ViewPeople = new Command(ViewPeopleImplementation);
        }

        public void LoadPeople()
        {
            Query allDocsQuery = App.CouchBaseInstance.CreateAllDocumentsQuery();

            QueryEnumerator results = allDocsQuery.Run();

            People.Clear();
            foreach (QueryRow result in results)
            {
                People.Add(new Person(result.Document.Properties));
            }

            OnPropertyChanged("People");
        }

        public void DeletePerson(Person toDelete)
        {
            Couchbase.Lite.View personView = App.CouchBaseInstance.GetView("GetAllPeople");

            //Can't just query by "Id = toDelete.Id" because you're creating a view in the database.  Need to create a 
            //mapping for all Person objects and then loop through those to find the one you want.  
            //Could put the DocumentId in the model when displaying the record, but that seems dirty because you already have a GUID for the object.

            personView.SetMap((props, emit) =>
            {
                if (props["ObjectType"].ToString() == "Person")
                {
                    emit("Id", props["Id"]);
                }
            }, "1");

            Query qry = personView.CreateQuery();

            QueryEnumerator results = qry.Run();

            foreach(QueryRow result in results)
            {
                if (result.Document.Properties["Id"].ToString() == toDelete.Id)
                {
                    result.Document.Delete();
                    break;
                }
            }

            //results.ElementAt(0).Document.Delete();

            LoadPeople();


        }

        private async void ViewPeopleImplementation(object obj)
        {
            await App.Navigation.PushAsync(new Page2());
        }

        private async void AddPersonImplementation(object obj)
        {
            Document couchBaseDoc = App.CouchBaseInstance.CreateDocument();
            couchBaseDoc.PutProperties(NewPerson.ToDictionary());

            NewPerson = new Person();

            await App.Navigation.PushAsync(new Page2());
        }
    }
}
