using FluentValidation;
namespace Person.Application.Mediators.Clients.GetById
{
    public class ClientFullValidator : AbstractValidator<ClientFullRequest>
    {
        public ClientFullValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
