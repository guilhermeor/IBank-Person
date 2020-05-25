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
        public Response(IReadOnlyCollection<Notification> notifications, T data)
        {
            AddNotifications(notifications);
            Data = data;
        }

        public T Data { get; }
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    }
}
