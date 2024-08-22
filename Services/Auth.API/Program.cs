using Auth.API.IdentityConfiguration;
using Auth.API.Validators;
using IdentityServer4.Services;
using IdentityServer4.Validation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServer()
    .AddInMemoryClients(Auth.API.IdentityConfiguration.Configuration.Clients)
    .AddInMemoryIdentityResources(Auth.API.IdentityConfiguration.Configuration.IdentityResources)
    .AddInMemoryApiResources(Auth.API.IdentityConfiguration.Configuration.ApiResources)
    .AddInMemoryApiScopes(Auth.API.IdentityConfiguration.Configuration.ApiScopes)
    .AddDeveloperSigningCredential();
builder.Services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();
builder.Services.AddTransient<IProfileService, ProfileService>();
// Add services to the container.

var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
app.UseRouting();
app.UseIdentityServer();
app.Run();

