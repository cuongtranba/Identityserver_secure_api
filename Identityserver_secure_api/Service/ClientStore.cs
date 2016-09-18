using System.Threading.Tasks;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;

namespace Identityserver_secure_api.Service
{
    public class ClientStore:IClientStore
    {
        public Task<Client> FindClientByIdAsync(string clientId)
        {
            throw new System.NotImplementedException();
        }
    }
}