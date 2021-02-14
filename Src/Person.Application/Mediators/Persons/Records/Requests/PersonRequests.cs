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

    public record PersonAddRequest(NameRequest Name, string Alias, DateTime BirthDay, int MonthlyIncome, string[] Phones, string Email, IdentificationRequest Identification) : IRequest<Response<object>>
    {
        public Domain.Person ToPerson() => new Domain.Person(Name.Parse(), BirthDay, Alias, MonthlyIncome)
                .WithContactInfo(Email, Phones.Select(p => p.Parse()))
                .WithIdentification(Identification.Parse());
    }

    public record PersonUpdateRequest(Guid Id, NameRequest Name, string Alias, DateTime BirthDay, int MonthlyIncome, string[] Phones, string Email, IdentificationRequest Identification) : IRequest<Response<object>>
    {
        public Domain.Person ToPerson() => new Domain.Person(Name.Parse(), BirthDay, Alias, MonthlyIncome)
                .WithContactInfo(Email, Phones.Select(p => p.Parse()))
                .WithIdentification(Identification.Parse());
    }

    public record PersonDeleteRequest(Guid Id) : IRequest<Response<object>>;
}
