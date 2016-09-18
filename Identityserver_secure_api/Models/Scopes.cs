using System.Collections.Generic;
using IdentityServer3.Core.Models;

namespace Identityserver_secure_api.Models
{
    public static class Scopes
    {
        public static List<Scope> Get()
        {
            return new List<Scope>
            {
                new Scope
                {
                    Name = "GetEmployee",
                }
            };

        }
    }
}