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

        public static explicit operator ClientFull(Client client)
        {
            return new ClientFull
            {
                Name = client.Name
            };
        }
    }
}
