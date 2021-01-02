using MediatR;
using System;

namespace Person.Application.Mediators.Person.Delete
{
    public class PersonDeleteRequest : IRequest<Response<object>>
    {
        public PersonDeleteRequest(Guid id) => Id = id;
        public Guid Id { get; }
    }
}
