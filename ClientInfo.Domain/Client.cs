using ClientInfo.Domain;
using System;
using System.Collections.Generic;

namespace ClientInfo.Domain
{
    public class Client
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public DateTime BirthDay { get; set; }
        public int MonthlyIncome { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<Document> Documents { get; set; }
        public Address Address { get; set; }

        public Client(string name, DateTime birthDay, string alias = default, int monthlyIncome = default)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            BirthDay = birthDay;
            Alias = alias;
            MonthlyIncome = monthlyIncome;
        }
        public Client WithAddress(Address address)
        {
            Address = address;
            return this;
        }
        public Client WithInfoContact(string phone, string email)
        {
            Phone = phone;
            Email = email;
            return this;
        }
        public Client WithDocuments(IEnumerable<Document> documents)
        {
            Documents = documents;
            return this;
        }
    }
}
