using Person.Application.Mediators.Clients.Requests;
using MediatR;
using System;

namespace Person.Application.Mediators.Clients.Add
{

    public class ClientAddRequest : IRequest<Response<object>>
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public DateTime BirthDay { get; set; }
        public int MonthlyIncome { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DocumentRequest[] Documents { get; set; }
        public AddressRequest Address { get; set; }


        public ClientAddRequest()
        {

        }
        public ClientAddRequest(string name, string alias, DateTime birthDay, int monthlyIncome) 
            => (Name, Alias, BirthDay, MonthlyIncome) = (name, alias, birthDay, monthlyIncome);

        public ClientAddRequest WithDocuments(DocumentRequest[] documents)
        {
            Documents = documents;
            return this;
        }

        public ClientAddRequest WithContactInfo(string phone, string email)
        {
            (Phone, Email) = (phone, email);
            return this;
        }
        public ClientAddRequest WithAddress(AddressRequest address)
        {
            Address = address;
            return this;
        }
    }
}
