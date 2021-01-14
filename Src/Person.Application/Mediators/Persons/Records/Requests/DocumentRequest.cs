using Person.Domain;
using Person.Domain.Enums;

namespace Person.Application.Mediators.Persons.Records.Requests
{
    public class DocumentRequest
    {
        public DocumentType Type { get; set; }
        public string Number { get; set; }

        public Document Parse() => new(Type, Number);
    }
}
