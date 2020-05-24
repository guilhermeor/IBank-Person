using Flunt.Notifications;
using System.Collections.Generic;
using System.Net;

namespace ClientInfo.Application
{
    public class Response<T> : Notifiable where T : class
    {
        public Response()
        {
        }
        public Response<T> Errors(IReadOnlyCollection<Notification> notifications, HttpStatusCode statusCode)
        {
            AddNotifications(notifications);
            StatusCode = statusCode;
            return this;
        }

        public T Data { get; }
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    }
}
