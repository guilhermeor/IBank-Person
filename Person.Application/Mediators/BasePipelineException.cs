using MediatR;
using MediatR.Pipeline;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Person.Application.Mediators
{
    public class BasePipelineException<TRequest, TResponse> :  IRequestExceptionHandler<TRequest, TResponse>
            where TRequest : IRequest<TResponse>
            where TResponse : ApiError, new()
    {
        public Task Handle(TRequest request, Exception exception, RequestExceptionHandlerState<TResponse> state, CancellationToken cancellationToken)
        {
            var response = new TResponse
            {
                Message = exception.Source == "Refit" ? "Error on External API" : exception.GetType().Name
            };
            state.SetHandled(response);
            return Task.CompletedTask;
        }
    }
}
