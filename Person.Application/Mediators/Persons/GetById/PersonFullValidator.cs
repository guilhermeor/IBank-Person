using FluentValidation;
namespace Person.Application.Mediators.Person.GetById
{
    public class PersonFullValidator : AbstractValidator<PersonFullRequest>
    {
        public PersonFullValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
