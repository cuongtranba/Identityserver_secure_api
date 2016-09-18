﻿using System;
using System.Security.Cryptography.X509Certificates;
using Identityserver_secure_api.Models;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Models;
using Owin;

namespace Identityserver_secure_api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseIdentityServer(new IdentityServerOptions
            {
                SiteName = "Embedded IdentityServer",
                SigningCertificate = LoadCertificate(),

                Factory = new IdentityServerServiceFactory()
                                .UseInMemoryUsers(Users.Get())
                                .UseInMemoryClients(Clients.Get())
                                .UseInMemoryScopes(Scopes.Get()),
                RequireSsl = false,
                AuthenticationOptions = new AuthenticationOptions()
                {
                    
                }
            });
        }

        X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2(
                string.Format(@"{0}\bin\idsrv3test.pfx", AppDomain.CurrentDomain.BaseDirectory), "idsrv3test");
        }
    }
}