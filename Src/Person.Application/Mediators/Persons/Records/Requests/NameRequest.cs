using Person.Domain;
using Person.Domain.ValueObjects;

namespace Person.Application.Mediators.Persons.Records.Requests
{
    public record NameRequest(string FirstName, string LastName)
    {
        public Name Parse() => new(FirstName, LastName);
    }
}