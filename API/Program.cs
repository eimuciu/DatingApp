using API.Data;
using API.Extensions;
using API.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
// builder.Services.AddScoped<ITokenService, TokenService>(); This is a scoped service mechanism that lives as much as controller lives upon creation. Short live time.
// builder.Services.AddTransient(); This is a transient service mechanism that lives when used and disposed after that. Short live time. This possibly can be used together with cache.
// builder.Services.AddSingleton(); This is a singleton service mechanism. It is created once and used by any class that injects the service. Lives as long as application lives.

// App builder
var app = builder.Build();

// Middlewares
app.UseMiddleware<ExceptionMiddleware>();
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync();
    // await Seed.SeedUsers(context);
}
catch (Exception ex)
{
    var logger = services.GetService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during migration");
}

app.Run();