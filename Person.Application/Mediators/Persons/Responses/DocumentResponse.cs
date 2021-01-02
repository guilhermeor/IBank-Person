using Person.Domain;

namespace Person.Application.Mediators.Persons
{
    public class DocumentResponse
    {
        public string Type { get; set; }
        public string Number { get; set; }

        public DocumentResponse(string type, string number) => (Type, Number) = (type, number);

        public static implicit operator DocumentResponse(Document document) => new(document.Type.ToString(), document.Number);
    }
}
