using Person.Application.Mediators.Clients.Requests;
using Person.Domain;
using MediatR;
using System;

namespace Person.Application.Mediators.Clients.Update
{
    public class ClientUpdateRequest : IRequest<Response<object>>
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
        public ClientUpdateRequest WithId(Guid id)
        {
            Id = id;
            return this;
        }
        public Client Parse()
        {
            return new Client(Name, BirthDay, Alias, MonthlyIncome, Id);
        }
    }
}
