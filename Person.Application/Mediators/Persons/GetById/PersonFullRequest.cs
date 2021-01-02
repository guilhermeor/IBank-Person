using MediatR;
using System;

namespace Person.Application.Mediators.Person.GetById
{
    public class PersonFullRequest : IRequest<Response<PersonFull>>
    {
        public Guid Id { get; set; }
        public PersonFullRequest(Guid id) => Id = id;
    }
}
