using Person.Domain;
using System;

namespace Person.Application.Mediators.Person.GetAll
{
    public readonly struct PersonShort
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Alias { get; init; }
        public DateTime BirthDay { get; init; }
        public string Email { get; init; }

        public PersonShort(Domain.Person person)
        {
            Id = person.Id;
            Name = person.Name;
            Alias = person.Alias;
            Email = person.Email;
            BirthDay = person.BirthDay;
        }

        public static implicit operator PersonShort(Domain.Person person) => new(person);
    }
}
