using MediatR;
using System.Collections.Generic;

namespace Person.Application.Mediators.Clients.GetAll
{
    public readonly struct ClientShortRequest : IRequest<Response<IEnumerable<ClientShort>>>
    {
        public int PageNumber { get; init; }
        public int PageSize { get; init; }

        public ClientShortRequest(int pageNumber, int pageSize) 
            => (PageNumber, PageSize) = (pageNumber, pageSize);
    }
}
