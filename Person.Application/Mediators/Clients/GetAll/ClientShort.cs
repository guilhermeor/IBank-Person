using Person.Domain;
using System;

namespace Person.Application.Mediators.Clients.GetAll
{
    public readonly struct ClientShort
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Alias { get; init; }
        public string FullPhoneNumber { get; init; }
        public string Email { get; init; }

        public ClientShort(Client client)
        {
            Id = client.Id;
            Name = client.Name;
            Alias = client.Alias;
            FullPhoneNumber = client.Phone?.FullPhoneNumber();
            Email = client.Email;
        }

        public static implicit operator ClientShort(Client client) => new(client);
    }
}
