using System;
using System.Collections.Generic;
using System.Linq;

namespace Person.Application.Mediators.Persons.Records.Responses
{
    public record PersonFull(Guid Id, string Name, string Alias, DateTime BirthDay, int MonthlyIncome, IEnumerable<string> Phones, string Email, IEnumerable<DocumentResponse> Documents, AddressResponse Address)
    {
        public static implicit operator PersonFull(Domain.Person person) 
            => new
            (
                person.Id,
                person.Name,
                person.Alias,
                person.BirthDay,
                person.MonthlyIncome,
                person.Phones.Select(p => p.FullPhoneNumber()),
                person.Email,
                person.Documents.Select(d => (DocumentResponse)d),
                person.Address
            );
    }
    public record PersonShort(Guid Id, string Name, string Alias, DateTime BirthDay, string Email)
    {
        public static explicit operator PersonShort(Domain.Person person)
            => new
            (
                person.Id,
                person.Name,
                person.Alias,
                person.BirthDay,
                person.Email                
            );
    }
}
