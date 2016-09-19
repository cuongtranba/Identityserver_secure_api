using System;
using AutoMapper;
using Identityserver_secure_api.Models;
using Identityserver_secure_api.Service.Interface;
using IdentityServer3.Core.Models;
using LiteDB;

namespace Identityserver_secure_api.Service.Implement
{
    public class ClientService : BaseService<ClientOAuth>, IClientService<Client>
    {
        public ClientService(LiteDatabase liteDatabase) : base(liteDatabase)
        {

        }

        public Client GetClientById(string clientId)
        {
            var clientOAuth = collection.FindOne(c => c.ClientId == int.Parse(clientId));
            return Mapper.Map<ClientOAuth, Client>(clientOAuth);
        }
    }
}
