using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Web;
using Microsoft.Extensions.DependencyInjection;
using IServiceProvider = System.IServiceProvider;
using Microsoft.AspNetCore.Http;
using System.Text;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json.Linq;
using MI.Constant.Lib;

namespace Auth.API.Validators
{

    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ResourceOwnerPasswordValidator(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            if (context.UserName.Equals("admin") && context.Password.Equals("admin"))
            {
                var claims = new List<Claim>
            {
                new Claim(AuthClaim.UserId, Guid.Empty.ToString()),
                new Claim(AuthClaim.UserName, "admin"),
                new Claim(AuthClaim.DisplayName, "Quản trị hệ thống"),
                new Claim(AuthClaim.Email, "demo@local.com"),
            };
                context.Result = new GrantValidationResult(context.UserName, "password", claims);
            }
            else
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "AUTHENTICATION_COMMON_ERROR");
            }
        }
    }
}