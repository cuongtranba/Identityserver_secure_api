using System.Collections.Generic;
using System.Threading.Tasks;
using Service.Model;

namespace Service.Service
{
    public interface IScopeService
    {
        Task<List<ScopeOAuth>> GetScopeByName(List<string> names);
    }
}
