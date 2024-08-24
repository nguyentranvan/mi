using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Test;
using System.Security.Claims;

namespace Auth.API.IdentityConfiguration
{
    public class ProfileService : IProfileService
    {
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            context.IssuedClaims = context.Subject.Claims.ToList();
            return Task.FromResult(0);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            return Task.FromResult(0);
        }
    }
    public class Configuration
    {
        public static IEnumerable<ApiResource> ApiResources =>
        new ApiResource[]
        {
            new ApiResource("lms.api")
            {
                Scopes = new List<string>{ "myApi.all" },
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
                RequireClientSecret = false,
                AllowOfflineAccess = true,
                AccessTokenLifetime =  60*60,
                AllowedScopes = { "myApi.all" },
                RefreshTokenExpiration = TokenExpiration.Sliding,
                RequireConsent = false
            }
        };

        public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("myApi.all"),
        };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
    }
}
