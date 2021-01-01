using MediatR;
using System;

namespace ClientInfo.Application.Mediators.Clients.GetById
{
    public class ClientFullRequest : IRequest<Response<ClientFull>>
    {
        public Guid Id { get; set; }
        public ClientFullRequest(Guid id) => Id = id;
    }
}
