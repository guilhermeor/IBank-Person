using MediatR;

namespace ClientInfo.Application.Mediators
{
    public interface IBaseNotificationHandler<in T> : INotificationHandler<T> where T : INotification
    {
    }
}
