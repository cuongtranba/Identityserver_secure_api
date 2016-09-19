using AutoMapper;
using Identityserver_secure_api.Models;
using IdentityServer3.Core.Models;

namespace Identityserver_secure_api.Automapper
{
    public static class Config
    {
        static Config()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ClientOAuth, Client>()
                    .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId))
                    .ForMember(dest => dest.ClientSecrets, opt => opt.MapFrom(src => src.ClientSecret))
                    .ForMember(dest => dest.Flow, opt => opt.MapFrom(src => src.Flow))
                    .ForMember(dest => dest.AllowedScopes, opt => opt.MapFrom(src => src.ScopeOAuths));
            });

        }
    }
}