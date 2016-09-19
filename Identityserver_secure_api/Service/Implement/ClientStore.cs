using System;
using System.Threading.Tasks;
using Identityserver_secure_api.Service.Interface;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;

namespace Identityserver_secure_api.Service.Implement
{
    public class ClientStore:IClientStore
    {
        private IClientService<Client> _clientService;

        public ClientStore(IClientService<Client> clientService)
        {
            _clientService = clientService;
        }

        public async Task<Client> FindClientByIdAsync(string clientId)
        {
            return await Task.Run(() => _clientService.GetClientById(clientId));
        }
    }
}