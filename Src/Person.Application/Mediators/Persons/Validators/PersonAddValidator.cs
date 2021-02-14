using FluentValidation;
using Person.Application.Mediators.Persons.Records.Requests;

namespace Person.Application.Mediators.Person.Validators
{
    public class PersonAddValidator : AbstractValidator<PersonAddRequest>
	{
		public PersonAddValidator()
		{
			RuleFor(x => x.Name.FirstName).NotEmpty();
			RuleFor(x => x.Name.LastName).NotEmpty();
			RuleFor(x => x.Email).EmailAddress();
			RuleFor(x => x.Alias).MinimumLength(3);
		}
    }
}
