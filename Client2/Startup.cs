using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Controllers;
using Client2.Service;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Owin;
using Thinktecture.IdentityModel.Extensions;
using Thinktecture.IdentityModel.WebApi;

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
            config.Filters.Add(new ResourceAuthorizeAttribute());
            app.UseResourceAuthorization(new AuthorizationManager());
            app.UseWebApi(config);
        }
    }


}