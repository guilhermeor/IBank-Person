using Person.Domain.Enums;

namespace Person.Domain
{
    public record Document (DocumentType Type, string Number);
}
