using ClientInfo.Application.Mediators.GetById;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace ClientInfo.Application.Mediators.Client.GetById
{
    public class ClientFull
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public DateTime BirthDay { get; set; }
        public int MonthlyIncome { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<DocumentResponse> Documents { get; set; }
        public AddressResponse Address { get; set; }
    }
}
