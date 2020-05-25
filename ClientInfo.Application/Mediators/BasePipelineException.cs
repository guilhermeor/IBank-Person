using Flunt.Notifications;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ClientInfo.Application.Mediators
{
    public class BasePipelineException<TRequest, TResponse, TException> :  IRequestExceptionHandler<TRequest, TResponse, TException>
            where TRequest : Notifiable, IRequest<TResponse>
            where TResponse : Notifiable, new()
            where TException : Exception
    {
        public Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state, CancellationToken cancellationToken)
        {
            var response = new TResponse();
            request.AddNotification(new Notification(exception.Source, $"Internal Server Error: {exception.Message}"));
            response.AddNotifications(request.Notifications);
            state.SetHandled(response);
            return Task.CompletedTask;
        }
    }
}
