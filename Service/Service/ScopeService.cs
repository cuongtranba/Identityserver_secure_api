using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using Service.Model;

namespace Service.Service
{
    public class ScopeService:BaseService,IScopeService
    {
        public ScopeService(LiteDatabase liteDatabase) : base(liteDatabase)
        {

        }

        public async Task<List<ScopeOAuth>> GetScopeByName(List<string> names)
        {
            var scopeOAuth = LiteDatabase.GetCollection<ScopeOAuth>($"{nameof(ScopeOAuth).ToLower()}s");
            return await Task.Run(() =>
            {
                return scopeOAuth.Find(c=>names.Contains(c.Name)).ToList();
            });
        }
    }
}
