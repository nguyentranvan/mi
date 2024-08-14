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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IServiceProvider = System.IServiceProvider;
using Microsoft.AspNetCore.Http;
using System.Text;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json.Linq;
using AuthServer.Api.Services;

namespace AuthServer.Validators
{

    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ResourceOwnerPasswordValidator(IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IAuthService authService)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _authService = authService;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = new Api.Models.LoginUser()
            {
                UserName = context.UserName,
                Password = context.Password
            };
            var claims = new List<Claim>();

            var loginResult = await _authService.Login(user);
            if (loginResult.IsLogedIn)
            {
                claims = new List<Claim>
                {
                    new Claim("Username", user.UserName),
                };
            }
            context.Result = new GrantValidationResult(user.UserName, "password", claims);
        }
    }
}