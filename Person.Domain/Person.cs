using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Person.Domain
{
    public class Person
    {
        [BsonId]
        public Guid Id { get; set; } 
        [BsonElement("name")]
        public string Name { get; set; }
        public string Alias { get; set; }
        public DateTime BirthDay { get; set; }
        public int MonthlyIncome { get; set; }
        public Phone Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<Document> Documents { get; set; }
        public Address Address { get; set; }

        public Person(string name, DateTime birthDay, string alias = default, int monthlyIncome = default, Guid id = default) 
            => (Id, Name, BirthDay, Alias, MonthlyIncome) = (id == Guid.Empty ? Guid.NewGuid() : id, name, birthDay, alias, monthlyIncome);
        public Person WithAddress(Address address)
        {
            Address = address;
            return this;
        }
        public Person WithDocuments(IEnumerable<Document> documents)
        {
            Documents = documents;
            return this;
        }
    }
}
