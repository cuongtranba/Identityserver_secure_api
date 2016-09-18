using System.Collections.Generic;

namespace Service.Model
{
    public class ClientOAuth
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public List<ScopeOAuth> Type { get; set; }
    }
}
