using FluentValidation;
using FluentValidation.Results;
using MediatR;
using OpenTracing;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Person.Application.Mediators
{
    [ExcludeFromCodeCoverage]
    public class FailFastPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
            where TRequest : IRequest<TResponse>
            where TResponse : ApiError, new()
    {

        private readonly IEnumerable<IValidator<TRequest>> validators;
        private readonly ITracer tracer;

        public FailFastPipelineBehavior(IEnumerable<IValidator<TRequest>> validators, ITracer tracer)
        {
            this.validators = validators;
            this.tracer = tracer;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {

            if (!validators.Any())
                return next();

            var failures = validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(f => f != null);

            if (failures.Any())
            {
                tracer.ActiveSpan.SetTag("validation", false);
                return Task.FromResult(Errors(failures));
            }
            return next();

        }

        private static TResponse Errors(IEnumerable<ValidationFailure> failures)
        {
            var response = new TResponse();
            response.AddFailureMessages(failures.Select(f => f.ErrorMessage));
            return response;
        }
    }
}
