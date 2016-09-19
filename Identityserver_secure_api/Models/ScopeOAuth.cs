using LiteDB;

namespace Identityserver_secure_api.Models
{
    public class ScopeOAuth
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool PublicOnly { get; set; } = true;
    }
}