using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientInfo.Domain.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAll(int pageNumber, int pageSize);
        Task<Client> Get(Guid id);
        Task Delete(Guid id);
        Task Update(Client client);
        Task Save(Client client);
    }
}
