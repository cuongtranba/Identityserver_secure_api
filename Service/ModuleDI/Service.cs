using Autofac;

namespace Service.ModuleDI
{
    public class Service : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly).Where(c => c.Name.EndsWith("Service")).AsImplementedInterfaces();
        }
    }
}
