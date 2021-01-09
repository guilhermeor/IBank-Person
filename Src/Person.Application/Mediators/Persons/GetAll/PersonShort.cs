using Person.Domain;
using System;

namespace Person.Application.Mediators.Person.GetAll
{
    public class PersonShort
    {
        public PersonShort()
        {

        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public DateTime BirthDay { get; set; }
        public string Email { get; set; }

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
