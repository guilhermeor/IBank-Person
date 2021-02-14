using System;
using Person.Domain;
using Person.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Tests.Core
{
    public partial class PersonTest
    {
        public static IEnumerable<object[]> PersonData()
        {
            return new List<object[]>
            {
                new object[] { new Name("Guilherme", "da Rosa"), DateTime.Now, "guile@gmail.com", new Phone("55", "51", "986555698"), new List<Document> { new Document(Domain.Enums.DocumentType.CPF,"05898956784")}},
                new object[] { new Name("Felix", "da Cunha"), DateTime.Now, "guile@gmail.com", new Phone("55", "51", "986555698"), new List<Document> { new Document(Domain.Enums.DocumentType.CPF,"874581518")}},
            };
        }
    }
}
