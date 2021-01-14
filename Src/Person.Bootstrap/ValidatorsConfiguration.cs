using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Person.Application.Mediators.Person.Validators;
using Person.Application.Mediators.Persons.Records.Requests;
using System.Globalization;

namespace Person.Bootstrap
{
    public static class ValidatorsConfiguration
    {
        public static IServiceCollection ConfigureValidators(this IServiceCollection services)
        {
            ValidatorOptions.Global.LanguageManager = new FluentValidation.Resources.LanguageManager() { Culture = CultureInfo.GetCultureInfo("en-US") };
            services.AddTransient<IValidator<PersonAddRequest>, PersonAddValidator>();
            services.AddTransient<IValidator<PersonFullRequest>, PersonFullValidator>();
            services.AddTransient<IValidator<PersonFullRequest>, PersonFullValidator>();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            return services;
        }
    }
}
