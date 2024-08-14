using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;
using static IdentityServer4.IdentityServerConstants;

namespace AuthServer.Configurations
{
    public class Config
    {

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
            };
        }

        public static IEnumerable<Client> GetClients(int sessionTimeout)
        {
            return new List<Client>
            {
                new Client
                {
                    RequireClientSecret = false,
                    ClientId = "web",
                    ClientName = "Web Client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowAccessTokensViaBrowser = true,
                    AllowOfflineAccess = true,
                    AllowedScopes = { StandardScopes.OfflineAccess },
                    AccessTokenLifetime = (sessionTimeout*60),
                    IdentityTokenLifetime =  (sessionTimeout*60),
                    RefreshTokenExpiration = TokenExpiration.Sliding,
                    SlidingRefreshTokenLifetime=(sessionTimeout*60) + (sessionTimeout*60),
                    RequireConsent = false
                }
            };
        }
    }

}
