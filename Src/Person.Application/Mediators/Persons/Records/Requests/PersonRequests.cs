using MediatR;
using Person.Application.Extensions;
using Person.Application.Mediators.Persons.Records.Responses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Person.Application.Mediators.Persons.Records.Requests
{
    public record PersonShortRequest(int PageNumber, int PageSize) : IRequest<Response<IEnumerable<PersonShort>>>;

    public record PersonFullRequest(Guid Id) : IRequest<Response<PersonFull>>;

    public record PersonAddRequest(string Name, string Alias, DateTime BirthDay, int MonthlyIncome, string[] Phones, string Email, DocumentRequest[] Documents, AddressRequest Address) : IRequest<Response<object>>
    {
        public Domain.Person ToPerson() => new Domain.Person(Name, BirthDay, Alias, MonthlyIncome)
                .WithContactInfo(Email, Phones.Select(p => p.Parse()))
                .WithAddress(Address.Parse())
                .WithDocuments(Documents.Select(d => d.Parse()));
    }

    public record PersonUpdateRequest(Guid Id, string Name, string Alias, DateTime BirthDay, int MonthlyIncome, string[] Phones, string Email, DocumentRequest[] Documents, AddressRequest Address) : IRequest<Response<object>>
    {
        public Domain.Person ToPerson() => new Domain.Person(Name, BirthDay, Alias, MonthlyIncome)
                .WithContactInfo(Email, Phones.Select(p => p.Parse()))
                .WithAddress(Address.Parse())
                .WithDocuments(Documents.Select(d => d.Parse()));
    }

    public record PersonDeleteRequest(Guid Id) : IRequest<Response<object>>;
}
