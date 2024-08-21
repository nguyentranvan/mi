using Auth.API.Validators;
using IdentityServer4.Validation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServer()
    .AddInMemoryClients(Auth.API.IdentityConfiguration.Configuration.Clients)
    .AddInMemoryIdentityResources(Auth.API.IdentityConfiguration.Configuration.IdentityResources)
    .AddInMemoryApiResources(Auth.API.IdentityConfiguration.Configuration.ApiResources)
    .AddInMemoryApiScopes(Auth.API.IdentityConfiguration.Configuration.ApiScopes)
    .AddDeveloperSigningCredential();
builder.Services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();

// Add services to the container.

var app = builder.Build();
// Configure the HTTP request pipeline.

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
});
app.UseRouting();
app.UseIdentityServer();
app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
