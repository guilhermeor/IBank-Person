using Person.Application.Mediators.Persons;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Person.Application.Mediators.Person.GetById
{
    public class PersonFull
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public DateTime BirthDay { get; set; }
        public int MonthlyIncome { get; set; }
        public IEnumerable<string> Phones { get; set; }
        public string Email { get; set; }
        public IEnumerable<DocumentResponse> Documents { get; set; }
        public AddressResponse Address { get; set; }

        public PersonFull(Domain.Person person)
        {
            Id = person.Id;
            Name = person.Name;
            Alias = person.Alias;
            BirthDay = person.BirthDay;
            MonthlyIncome = person.MonthlyIncome;
            Phones = person.Phones.Select(p => p.FullPhoneNumber());
            Email = person.Email;
            Documents = person.Documents.Select(d => (DocumentResponse)d);
            Address = person.Address;
        }

        public static implicit operator PersonFull(Domain.Person person) => new(person);
    }
}
