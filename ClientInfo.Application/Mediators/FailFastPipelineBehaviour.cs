using Flunt.Notifications;
using MediatR;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ClientInfo.Application.Mediators
{
    [ExcludeFromCodeCoverage]
    public class FailFastPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
            where TRequest : Notifiable, IRequest<TResponse>
            where TResponse : Response<TResponse>, new()
    {
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (request.Invalid)
            {
                var response = new TResponse();
                response.Errors(request.Notifications, HttpStatusCode.BadRequest);
                return Task.FromResult(response);
            }
            return next();
        }
    }
}
