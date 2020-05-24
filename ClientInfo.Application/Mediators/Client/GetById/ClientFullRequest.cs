using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using System;
using System.Collections.Generic;

namespace ClientInfo.Application.Mediators.Client.GetById
{
    public class ClientFullRequest : Notifiable, IRequest<Response<IEnumerable<ClientFull>>>
    {
        public Guid Id { get; set; }
        public ClientFullRequest(Guid id)
        {
            Id = id;

            AddNotifications(new Contract()
                .IfNotNull(Id, c =>
                c.AreNotEquals(Id, Guid.Empty, "CashInId", "Cash In Id should not be empty or null.")));
        }
    }
}
