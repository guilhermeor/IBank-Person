using MediatR;
using System.Collections.Generic;

namespace Person.Application.Mediators.Person.GetAll
{
    public readonly struct PersonShortRequest : IRequest<Response<IEnumerable<PersonShort>>>
    {
        public int PageNumber { get; init; }
        public int PageSize { get; init; }

        public PersonShortRequest(int pageNumber, int pageSize) 
            => (PageNumber, PageSize) = (pageNumber, pageSize);
    }
}
