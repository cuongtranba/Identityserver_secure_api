namespace Identityserver_secure_api.Service.Interface
{
    public interface IClientService<V>
    {
        V GetClientById(string clientId);
    }
}
