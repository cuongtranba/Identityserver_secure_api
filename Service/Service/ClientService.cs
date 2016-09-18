using System.Collections.Generic;
using System.Threading.Tasks;
using LiteDB;
using Service.Model;

namespace Service.Service
{
    public class ClientService:BaseService,IClientService
    {
        public Task<List<ClientOAuth>> GetClientById(string id)
        {
            throw new System.NotImplementedException();
        }

        public ClientService(LiteDatabase liteDatabase) : base(liteDatabase)
        {

        }
    }
}
