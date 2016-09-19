using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identityserver_secure_api.Service.Interface;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;

namespace Identityserver_secure_api.Service.Implement
{
    public class ScopeStore:IScopeStore
    {
        private IScopeService<Scope> _scopeService;

        public ScopeStore(IScopeService<Scope> scopeService)
        {
            _scopeService = scopeService;
        }

        public async Task<IEnumerable<Scope>> FindScopesAsync(IEnumerable<string> scopeNames)
        {
            return await Task.Run(() => _scopeService.GetScopeByName(scopeNames.ToList()));
        }

        public async Task<IEnumerable<Scope>> GetScopesAsync(bool publicOnly = true)
        {
            return await Task.Run(() => _scopeService.GetScopesAsync(publicOnly));
        }
    }
}