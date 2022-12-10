using System.Text;
using API.Data;
using API.Extensions;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();