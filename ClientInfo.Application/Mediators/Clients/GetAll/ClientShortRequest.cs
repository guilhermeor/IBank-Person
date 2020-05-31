using Flunt.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientInfo.Application.Mediators.Clients.GetAll
{
    public class ClientShortRequest : Notifiable, IRequest<Response<IEnumerable<ClientShort>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public ClientShortRequest(int pageNumber, int pageSize) 
            => (PageNumber, PageSize) = (pageNumber, pageSize);
    }
}
