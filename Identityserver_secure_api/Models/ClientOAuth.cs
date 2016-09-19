using System;
using System.Collections.Generic;
using IdentityServer3.Core.Models;
using LiteDB;

namespace Identityserver_secure_api.Models
{
    public class ClientOAuth
    {
        [BsonId]
        public int ClientId { get; set; }
        public string ClientSecret { get; set; }
        public List<ScopeOAuth> ScopeOAuths { get; set; } = new List<ScopeOAuth>();
        public Flows Flow { get; set; } = Flows.ClientCredentials;
    }
}
