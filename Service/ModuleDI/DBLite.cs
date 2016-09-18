using System;
using Autofac;
using LiteDB;

namespace Service.ModuleDI
{
    public class DbLite:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var dblite = new LiteDatabase($"{AppDomain.CurrentDomain.BaseDirectory}..\\LiteDb\\TodoDb.db");
            builder.Register(c => dblite).AsSelf().InstancePerRequest();
        }
    }
}
