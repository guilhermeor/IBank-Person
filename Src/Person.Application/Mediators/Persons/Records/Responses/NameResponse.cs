using Person.Domain;
using Person.Domain.ValueObjects;

namespace Person.Application.Mediators.Persons.Records.Responses
{
    public record NameResponse(string FirstName, string LastName)
    {
        public static implicit operator NameResponse(Name name) => new(name.FirstName, name.LastName);
    }
}
