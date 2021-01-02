using Person.Domain;
using System;

namespace Person.Application.Mediators.Person.GetAll
{
    public readonly struct PersonShort
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Alias { get; init; }
        public string FullPhoneNumber { get; init; }
        public string Email { get; init; }

        public PersonShort(Domain.Person client)
        {
            Id = client.Id;
            Name = client.Name;
            Alias = client.Alias;
            FullPhoneNumber = client.Phone?.FullPhoneNumber();
            Email = client.Email;
        }

        public static implicit operator PersonShort(Domain.Person client) => new(client);
    }
}
