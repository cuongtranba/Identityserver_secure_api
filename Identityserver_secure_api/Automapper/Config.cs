using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoMapper;
using Identityserver_secure_api.Models;
using IdentityServer3.Core.Models;

namespace Identityserver_secure_api.Automapper
{
    public static class Config
    {
        public static IMapper Mapper { get; set; }
        static Config()
        {
            Mapper = new MapperConfiguration(cfg =>
              {
                  cfg.CreateMap<string, List<Secret>>().ConvertUsing<ClientSecretConverter>();
                  cfg.CreateMap<ClientOAuth, Client>()
                      .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId))
                      .ForMember(dest => dest.Flow, opt => opt.MapFrom(src => src.Flow))
                      .ForMember(dest => dest.ClientSecrets, opt => opt.MapFrom(src => src.ClientSecret))
                      .ForMember(dest => dest.AllowedScopes, opt => opt.MapFrom(src => src.ScopeOAuths.Select(c=>c.Name)));
                  cfg.CreateMap<ScopeOAuth, Scope>()
                      .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
              }).CreateMapper();
        }
    }

    internal class ClientSecretConverter : ITypeConverter<string, List<Secret>>
    {
        public List<Secret> Convert(string source, List<Secret> destination, ResolutionContext context)
        {
            if ((destination == null || !destination.Any()) && !string.IsNullOrEmpty(source))
            {
                destination=new List<Secret>()
                {
                    new Secret(source.Sha256())
                };
            }
            return destination;
        }
    }

}