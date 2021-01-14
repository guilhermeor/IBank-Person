using FluentValidation;
using Person.Application.Mediators.Persons.Records.Requests;

namespace Person.Application.Mediators.Person.Validators
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
