using System.Collections.Generic;

namespace Person.Domain
{
    public readonly struct Identification
    {        
        public string CpfNumber { get; init; }
        public IEnumerable<Document> Documents { get; init; }
        public Identification(string cpfNumber, IEnumerable<Document> documents) => (CpfNumber, Documents) = (Cpf.Parse(cpfNumber).ToString(), documents);
    }
}