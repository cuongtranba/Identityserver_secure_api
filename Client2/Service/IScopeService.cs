using System;
using System.Linq;
using Identityserver_secure_api.Models;
using LiteDB;

namespace Client2.Service
{
    public interface IScopeService
    {
        bool IsClientInScope(int clientId, string scopeName);
    }

    public class ScopeService : IScopeService
    {
        public bool IsClientInScope(int clientId, string scopeName)
        {
            //G:\VisualStudioProject\Identityserver_secure_api\ClientConsole
            using (var db = new LiteDatabase($"{AppDomain.CurrentDomain.BaseDirectory }..\\ClientConsole\\OAuthDB.db"))
            {
                var clientCollections = db.GetCollection<ClientOAuth>("clientoauths");
                var client = clientCollections.FindOne(c => c.ClientId == clientId);
                if (client != null)
                {
                    return client.ScopeOAuths.Any(c => c.Name == scopeName.ToLower());
                }
                return false;
            }
        }
    }
}