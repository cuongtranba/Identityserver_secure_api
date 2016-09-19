using System;
using System.Security.Cryptography.X509Certificates;
using Identityserver_secure_api.Service;
using Identityserver_secure_api.Service.Implement;
using Identityserver_secure_api.Service.Interface;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using LiteDB;
using Owin;

namespace Identityserver_secure_api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var factory = new IdentityServerServiceFactory();
            factory.Register(new Registration<LiteDatabase>($"{ AppDomain.CurrentDomain.BaseDirectory }..\\LiteDb\\OAuthDB.db"));
            factory.Register(new Registration<IScopeService<Scope>, ScopeService>());
            factory.Register(new Registration<IClientService<Client>, ClientService>());

            factory.ClientStore = new Registration<IClientStore, ClientStore>();
            factory.ScopeStore = new Registration<IScopeStore, ScopeStore>();
            app.UseIdentityServer(new IdentityServerOptions
            {
                SiteName = "Embedded IdentityServer",
                SigningCertificate = LoadCertificate(),

                //Factory = new IdentityServerServiceFactory()
                //                .UseInMemoryUsers(Users.Get())
                //                .UseInMemoryClients(Clients.Get())
                //                .UseInMemoryScopes(Scopes.Get()),
                Factory = factory,
                RequireSsl = false,
            });
        }

        X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2(
                string.Format(@"{0}\bin\idsrv3test.pfx", AppDomain.CurrentDomain.BaseDirectory), "idsrv3test");
        }
    }
}