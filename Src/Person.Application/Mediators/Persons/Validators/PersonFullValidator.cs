using FluentValidation;
using Person.Application.Mediators.Persons.Records.Requests;

namespace Person.Application.Mediators.Person.Validators
{
    public class PersonFullValidator : AbstractValidator<PersonFullRequest>
    {
        public PersonFullValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
