using System.Web.UI;
using LiteDB;

namespace Identityserver_secure_api.Service.Implement
{
    public abstract class BaseService<T> where T: new()
    {
        private readonly LiteDatabase _liteDatabase;
        protected LiteCollection<T> collection;
        protected BaseService(LiteDatabase liteDatabase)
        {
            _liteDatabase = liteDatabase;
            collection = _liteDatabase.GetCollection<T>($"{typeof(T).Name.ToLower()}s");
        }
    }
}
