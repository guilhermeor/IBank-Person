using FluentValidation;

namespace Person.Application.Mediators.Person.Add
{
    public class PersonAddValidator : AbstractValidator<PersonAddRequest>
	{
		public PersonAddValidator()
		{
			RuleFor(x => x.Name).NotEmpty();
			RuleFor(x => x.Email).EmailAddress();
			RuleFor(x => x.Alias).MinimumLength(3);
		}
    }
}
