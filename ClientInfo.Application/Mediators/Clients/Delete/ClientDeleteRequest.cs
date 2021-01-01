﻿using MediatR;
using System;

namespace ClientInfo.Application.Mediators.Clients.Delete
{
    public class ClientDeleteRequest : IRequest<Response<object>>
    {
        public ClientDeleteRequest(Guid id) => Id = id;
        public Guid Id { get; }
    }
}
