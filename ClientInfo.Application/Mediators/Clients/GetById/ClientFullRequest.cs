using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using System;

namespace ClientInfo.Application.Mediators.Clients.GetById
{
    public class ClientFullRequest : Notifiable, IRequest<Response<ClientFull>>
    {
        public string Id { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public ClientFullRequest(string id, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Id = id;

            AddNotifications(new Contract()
                .IfNotNull(Id, c =>
                c.AreNotEquals(Id, Guid.Empty, "CashInId", "Cash In Id should not be empty or null.")));
        }
    }
}
