using ClientInfo.Domain;
using System;
using System.Collections.Generic;

namespace ClientInfo.Application.Mediators.Clients.GetById
{
    public class ClientFull
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

        public ClientFull(Client client)
        {
            Id = client.Id;
            Name = client.Name;
            Alias = client.Alias;
            BirthDay = client.BirthDay;
            MonthlyIncome = client.MonthlyIncome;
            Phone = client.Phone?.FullPhoneNumber();
            Email = client.Email;
        }

        public static implicit operator ClientFull(Client client) => new(client);
    }
}
