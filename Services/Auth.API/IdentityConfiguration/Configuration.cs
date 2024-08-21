using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace Auth.API.IdentityConfiguration
{
    public class Configuration
    {
        public static IEnumerable<ApiResource> ApiResources =>
        new ApiResource[]
        {
            new ApiResource("lms.api")
            {
                Scopes = new List<string>{ "myApi.read","myApi.write" },
                ApiSecrets = new List<Secret>{ new Secret("supersecret".Sha256()) }
            }
        };
        public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new Client
            {
                ClientId = "web",
                ClientName = "Client web",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedScopes = { "myApi.read" }
            },
        };

        public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("myApi.read"),
            new ApiScope("myApi.write"),
        };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
    }
}
