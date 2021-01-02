using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using Person.Application.Mediators;

namespace Person.Bootstrap
{
    public static class MediatorConfiguration
    {
        public static IServiceCollection ConfigureMediator(this IServiceCollection services)
        {
            services.AddMediatR(typeof(IBaseHandler<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastPipelineBehavior<,>));
            services.AddScoped(typeof(IRequestExceptionHandler<,>), typeof(BasePipelineException<,>));
            return services;
        }
    }
}
