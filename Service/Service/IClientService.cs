using System.Collections.Generic;
using System.Threading.Tasks;
using Service.Model;

namespace Service.Service
{
    public interface IClientService
    {
        Task<List<ClientOAuth>> GetClientById(string id);
    }
}
