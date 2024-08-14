using AuthServer.Api.Contextes;
using AuthServer.Api.Models;
using AuthServer.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;
using AuthServer.Configurations;
using Microsoft.Extensions.Configuration;
using AuthServer.Validators;
using IdentityServer4.Validation;

namespace AuthServer.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.      
            builder.Services.AddDbContext<AuthDemoDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value);
            });
            //
            var sessionTimeout = 60;
            builder.Services.AddIdentityServer(options =>
                {
                    options.IssuerUri = "http://localhost:5092";
                })
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryClients(Config.GetClients(sessionTimeout))
                .AddDeveloperSigningCredential();
            //
            builder.Services.AddCors();
            //
            builder.Services.AddIdentity<ExtendedIdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AuthDemoDbContext>();
           
            builder.Services.AddTransient<IAuthService, AuthService>();
            builder.Services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(policy =>
            {
                policy.WithOrigins("http://localhost:4200");
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowCredentials();
            });

            app.MapControllers();
            app.UseRouting();
            app.UseIdentityServer();
            app.Run();
        }
    }
}