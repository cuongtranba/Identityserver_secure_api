using System.Linq;
using System.Threading.Tasks;
using Client2.Service;
using Thinktecture.IdentityModel.Extensions;
using Thinktecture.IdentityModel.Owin.ResourceAuthorization;

namespace Client2
{
    public class AuthorizationManager : ResourceAuthorizationManager
    {
        public override Task<bool> CheckAccessAsync(ResourceAuthorizationContext context)
        {
            IScopeService scopeService=new ScopeService();
            var clientId = context.Principal.Claims.GetValue("client_id");
            var action = context.Action.FirstOrDefault().Value;
            var result = scopeService.IsClientInScope(int.Parse(clientId), action.ToLower());
            return Eval(result);
        }
    }
}