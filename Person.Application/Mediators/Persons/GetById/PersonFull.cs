using Person.Application.Mediators.Persons;
using System;
using System.Collections.Generic;

namespace Person.Application.Mediators.Person.GetById
{
    public class PersonFull
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public DateTime BirthDay { get; set; }
        public int MonthlyIncome { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<DocumentResponse> Documents { get; set; }
        public AddressResponse Address { get; set; }

        public PersonFull(Domain.Person client)
        {
            Id = client.Id;
            Name = client.Name;
            Alias = client.Alias;
            BirthDay = client.BirthDay;
            MonthlyIncome = client.MonthlyIncome;
            Phone = client.Phone?.FullPhoneNumber();
            Email = client.Email;
        }

        public static implicit operator PersonFull(Domain.Person client) => new(client);
    }
}
