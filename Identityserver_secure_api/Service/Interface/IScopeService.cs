using System.Collections.Generic;
using Identityserver_secure_api.Models;

namespace Identityserver_secure_api.Service.Interface
{
    public interface IScopeService<V>
    {
        List<V> GetScopeByName(List<string> names);
        List<V> GetScopesAsync(bool publicOnly);
    }
}
