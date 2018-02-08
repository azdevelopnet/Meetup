using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CouchbaseDemo.Models
{
    public class Person
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string ObjectType { get; set; } = "Person";

        public Person()
        {
        }

        public Person(IDictionary<string,object> couchbaseItem)
        {
            this.Id = couchbaseItem["Id"].ToString();
            this.FirstName = couchbaseItem["FirstName"].ToString();
            this.LastName = couchbaseItem["LastName"].ToString();
            this.PhoneNumber = couchbaseItem["PhoneNumber"].ToString();
        }

        public IDictionary<string, object> ToDictionary()
        {
            return new Dictionary<string, object>()
            {
                {"Id", this.Id },
                {"FirstName", this.FirstName },
                {"LastName", this.LastName },
                {"PhoneNumber", this.PhoneNumber },
                {"ObjectType", this.ObjectType }
            };
        }
    }
}
