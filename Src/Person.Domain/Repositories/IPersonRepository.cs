using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Person.Domain.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAll(int pageNumber, int pageSize);
        Task<Person> Get(Guid id);
        Task<bool> Exists(Expression<Func<Person, bool>> filterExpression);
        Task Delete(Guid id);
        Task Update(Person person);
        Task Save(Person person);
    }
}
