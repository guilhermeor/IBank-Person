using Person.Domain.Enums;

namespace Person.Domain
{
    public class Document
    {
        public DocumentType Type { get; set; }
        public string Number { get; set; }
        public Document(DocumentType type, string number) => (Type, Number) = (type, number);
    }
}
