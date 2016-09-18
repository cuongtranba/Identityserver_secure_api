using LiteDB;

namespace Service.Service
{
    public abstract class BaseService
    {
        protected LiteDatabase LiteDatabase;

        protected BaseService(LiteDatabase liteDatabase)
        {
            this.LiteDatabase = liteDatabase;
        }
    }
}
