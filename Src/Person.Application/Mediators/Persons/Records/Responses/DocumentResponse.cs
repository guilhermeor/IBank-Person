using Person.Domain;

namespace Person.Application.Mediators.Persons.Records.Responses
{
    public record DocumentResponse(string Type, string Number)
    {
        public static implicit operator DocumentResponse(Document document) => new(document.Type.ToString(), document.Number);
    }
}
