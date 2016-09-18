using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer3.Core;
using IdentityServer3.Core.Models;

namespace Identityserver_secure_api.Models
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[]
            {
                new Client
                {
                    Enabled = true,
                    ClientName = "MVC Client",
                    ClientId = "ClientId",
                    Flow = Flows.ClientCredentials,
                    RedirectUris = new List<string>
                    {
                        "http://localhost:4408/"
                    },
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("F621F470-9731-4A25-80EF-67A6F7C5F4B8".Sha256())
                    },
                    AllowAccessToAllScopes = true,
                    AllowedScopes = new List<string>()
                    {
                        "GetEmployee"
                    },
                }
            };
        }

    }
}