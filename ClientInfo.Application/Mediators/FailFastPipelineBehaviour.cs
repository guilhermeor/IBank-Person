using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ClientInfo.Application.Mediators
{
    [ExcludeFromCodeCoverage]
    public class FailFastPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
            where TRequest : IRequest<TResponse>
            where TResponse : ApiError, new()
    {

        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public FailFastPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {

            if (!_validators.Any())
                return next();

            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(f => f != null);

            return failures.Any()
                ? Task.FromResult(Errors(failures))
                : next();

        }

        private static TResponse Errors(IEnumerable<ValidationFailure> failures)
        {
            var response = new TResponse();
            response.AddFailureMessages(failures.Select(f => f.ErrorMessage));
            return response;
        }
    }
}
