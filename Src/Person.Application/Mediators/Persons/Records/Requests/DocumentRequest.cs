using Person.Domain;
using Person.Domain.Enums;

namespace Person.Application.Mediators.Persons.Records.Requests
{
    public record DocumentRequest(DocumentType Type, string Number)
    {
        public Document Parse() => new(Type, Number);
    }
}
