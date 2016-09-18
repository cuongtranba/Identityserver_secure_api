using System.Web.Http;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Owin;
[assembly: OwinStartup(typeof(Client2.Startup))]
namespace Client2
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // accept access tokens from identityserver and require a scope of 'api1'
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "http://localhost:44351",
                ValidationMode = ValidationMode.ValidationEndpoint,
            });

            // configure web api
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            // require authentication for all controllers
            config.Filters.Add(new AuthorizeAttribute());
            app.UseResourceAuthorization(new AuthorizationManager());
            app.UseWebApi(config);
        }
    }
}