using FluentValidation;

namespace Person.Application.Mediators.Clients.Add
{
    public class ClientAddValidator : AbstractValidator<ClientAddRequest>
	{
		public ClientAddValidator()
		{
			RuleFor(x => x.Name).NotEmpty();
			RuleFor(x => x.Email).EmailAddress();
			RuleFor(x => x.Alias).MinimumLength(3);
		}
    }
}
