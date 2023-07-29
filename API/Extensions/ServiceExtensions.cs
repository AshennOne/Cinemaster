using API.Data;
using API.Data.Repositories;
using API.Helpers;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace API.Extensions;

public static class ServiceExtensions
{
  public static IServiceCollection LoadServices(this IServiceCollection services, ConfigurationManager configuration)
  {
    services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(configuration.GetConnectionString("Default")));
    services.AddCors(options =>
    {
      options.AddPolicy("AllowAngularApp",
      builder => builder.WithOrigins("http://localhost:4200")
      .AllowAnyHeader()
      .AllowAnyMethod());
    });
    services.AddScoped<ITokenService,TokenService>();
     services.AddSingleton<IConfiguration>(configuration);
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddEndpointsApiExplorer();

    return services;
  }
}