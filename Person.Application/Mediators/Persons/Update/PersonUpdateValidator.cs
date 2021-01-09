using FluentValidation;
using Person.Application.Mediators.Person.Update;

namespace Person.Application.Mediators.Persons.Update
{
    public class PersonUpdateValidator : AbstractValidator<PersonUpdateRequest>
    {
		public PersonUpdateValidator()
		{
			RuleFor(x => x.Name).NotEmpty();
			RuleFor(x => x.Email).EmailAddress();
			RuleFor(x => x.Alias).MinimumLength(3);
		}
	}
}
