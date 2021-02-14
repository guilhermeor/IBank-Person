using System;
using System.Collections.Generic;
using System.Linq;

namespace Person.Application.Mediators.Persons.Records.Responses
{
    public record PersonFull(Guid Id, NameResponse Name, string Alias, DateTime BirthDay, decimal MonthlyIncome, IEnumerable<string> Phones, string Email, IdentificationResponse Documents)
    {
        public static implicit operator PersonFull(Domain.Person person)
        {
            Domain.ValueObjects.Name name = person.Name;
            return new
                        (
                            person.Id,
                            name,
                            person.Alias,
                            person.BirthDay,
                            person.MonthlyIncome,
                            person.Phones.Select(p => p.FullPhoneNumber()),
                            person.Email,
                            person.Identification
                        );
        }
    }
    public record PersonShort(Guid Id, string Name, string Alias, DateTime BirthDay, string Email)
    {
        public static explicit operator PersonShort(Domain.Person person)
            => new
            (
                person.Id,
                person.FullName(),
                person.Alias,
                person.BirthDay,
                person.Email                
            );
    }
}
