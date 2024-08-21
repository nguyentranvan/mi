using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var authority = builder.Configuration["Jwt:Issuer"];
var apiName = builder.Configuration["Jwt:ApiName"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddIdentityServerAuthentication("Bearer", options =>
{
    options.ApiName = apiName;
    options.Authority = authority;
    options.RequireHttpsMetadata = false;
});
//
builder.Services.AddControllers();
builder.Services.AddAuthorization();
// Add services to the container.
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
