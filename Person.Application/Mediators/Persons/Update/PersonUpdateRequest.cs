using MediatR;
using Person.Application.Mediators.Person.Requests;
using Person.Domain;
using System;

namespace Person.Application.Mediators.Person.Update
{
    public class PersonUpdateRequest : IRequest<Response<object>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public DateTime BirthDay { get; set; }
        public int MonthlyIncome { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DocumentRequest[] Documents { get; set; }
        public AddressRequest Address { get; set; }
        public PersonUpdateRequest WithId(Guid id)
        {
            Id = id;
            return this;
        }
        public Domain.Person Parse()
        {
            return new Domain.Person(Name, BirthDay, Alias, MonthlyIncome, Id);
        }
    }
}
