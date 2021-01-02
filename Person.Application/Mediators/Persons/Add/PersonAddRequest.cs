using MediatR;
using Person.Application.Mediators.Person.Requests;
using System;

namespace Person.Application.Mediators.Person.Add
{

    public class PersonAddRequest : IRequest<Response<object>>
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public DateTime BirthDay { get; set; }
        public int MonthlyIncome { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DocumentRequest[] Documents { get; set; }
        public AddressRequest Address { get; set; }


        public PersonAddRequest()
        {

        }
        public PersonAddRequest(string name, string alias, DateTime birthDay, int monthlyIncome) 
            => (Name, Alias, BirthDay, MonthlyIncome) = (name, alias, birthDay, monthlyIncome);

        public PersonAddRequest WithDocuments(DocumentRequest[] documents)
        {
            Documents = documents;
            return this;
        }

        public PersonAddRequest WithContactInfo(string phone, string email)
        {
            (Phone, Email) = (phone, email);
            return this;
        }
        public PersonAddRequest WithAddress(AddressRequest address)
        {
            Address = address;
            return this;
        }
    }
}
