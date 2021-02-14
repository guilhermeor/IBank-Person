using MongoDB.Bson.Serialization.Attributes;
using Person.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Person.Domain
{
    public class Person
    {
        [BsonId]
        public Guid Id { get; init; }
        public Name Name { get; init; }
        public string Alias { get; init; }
        public DateTime BirthDay { get; init; }
        public decimal MonthlyIncome { get; init; }
        public string Email { get; set; }
        public IEnumerable<Phone> Phones { get; set; }
        public Identification Identification { get; set; }
        public int Age()
        {
            var years = DateTime.Now.Year - BirthDay.Year;
            return (DateTime.Now.DayOfYear < BirthDay.DayOfYear) ? years -1 : years;
        }

        public string FullName() => $"{Name.FirstName} {Name.FirstName} {Name.LastName}";
        public string PrincipalPhone() => Phones.FirstOrDefault(p => p.Principal).FullPhoneNumber();

        public Person() { }
        public Person(Name name, DateTime birthDay, string alias = default, int monthlyIncome = default, Guid id = default)
            => (Id, Name, BirthDay, Alias, MonthlyIncome) = (id == Guid.Empty ? Guid.NewGuid() : id, name, birthDay, alias, monthlyIncome);

        public Person WithContactInfo(string email, IEnumerable<Phone> phones)
        {
            (Email, Phones) = (email, phones);
            return this;
        }

        public Person WithIdentification(Identification identification)
        {
            Identification = identification;
            return this;
        }
    }
}
