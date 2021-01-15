using MediatR;
using MediatR.Pipeline;
using OpenTracing;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Person.Application.Mediators
{
    public class BasePipelineException<TRequest, TResponse, TException> :  IRequestExceptionHandler<TRequest, TResponse, TException>
            where TRequest : IRequest<TResponse>
            where TResponse : ApiError, new()
            where TException : Exception
    {
        private readonly ITracer tracer;

        public BasePipelineException(ITracer tracer) => this.tracer = tracer;
        public Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state, CancellationToken cancellationToken)
        {            
            var response = new TResponse
            {                
                Message = exception.Source == "Refit" ? "Error on External API" : exception.GetType().Name
            };
            tracer.ActiveSpan.SetTag("exception", true);
            tracer.ActiveSpan.Log(exception.StackTrace);

            state.SetHandled(response);
            return Task.CompletedTask;
        }
    }
}
