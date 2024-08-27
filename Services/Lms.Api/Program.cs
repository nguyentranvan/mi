using IdentityServer4.AccessTokenValidation;
using Lms.API.DAL;
using MI.DBContext.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var configuration =  builder.Configuration;

builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer(configuration.GetConnectionString("CoreConnection")));

#region Indentity4
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
    options.SupportedTokens = IdentityServer4.AccessTokenValidation.SupportedTokens.Both;
    options.RequireHttpsMetadata = false;
});
#endregion
//
#region Add Services 
builder.Services.AddAuthorization();
builder.Services.AddScoped<IAProfileDAL, AProfileDAL>();
builder.Services.AddScoped<IACertificateDAL, ACertificateDAL>();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
});
#endregion
//
builder.Services.AddCors();
// Add services to the container.
var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

