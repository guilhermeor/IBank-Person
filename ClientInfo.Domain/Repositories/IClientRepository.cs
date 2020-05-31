using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientInfo.Domain.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAll(int pageNumber, int pageSize);
        Task<Client> Get(string id);
        void Delete(string id);
        void Update(Client client);
        void Save(Client client);
    }
}
