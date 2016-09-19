using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Identityserver_secure_api.Models;
using Identityserver_secure_api.Service.Interface;
using IdentityServer3.Core.Models;
using LiteDB;

namespace Identityserver_secure_api.Service.Implement
{
    public class ScopeService : BaseService<ScopeOAuth>, IScopeService<Scope>
    {
        public ScopeService(LiteDatabase liteDatabase) : base(liteDatabase)
        {

        }

        public List<Scope> GetScopeByName(List<string> names)
        {
            var scopeOAuth = this.collection.Find(c => names.Contains(c.Name)).ToList();
            return Mapper.Map<List<ScopeOAuth>, List<Scope>>(scopeOAuth);
        }

        public List<Scope> GetScopesAsync(bool publicOnly)
        {
            var scopeOAuth = this.collection.Find(c => c.PublicOnly == publicOnly).ToList();
            return Mapper.Map<List<ScopeOAuth>, List<Scope>>(scopeOAuth);
        }
    }
}
