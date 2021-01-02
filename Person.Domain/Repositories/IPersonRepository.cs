using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Person.Domain.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAll(int pageNumber, int pageSize);
        Task<Person> Get(Guid id);
        Task Delete(Guid id);
        Task Update(Person client);
        Task Save(Person client);
    }
}
