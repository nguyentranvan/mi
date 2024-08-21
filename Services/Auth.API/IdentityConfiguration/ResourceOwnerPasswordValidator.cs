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
            var claims = new List<Claim>();
            context.Result = new GrantValidationResult(context.UserName, "password", claims);
        }
    }
}