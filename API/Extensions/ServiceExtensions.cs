using API.Data;
using API.Data.Repositories;
using API.Helpers;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace API.Extensions;

public static class ServiceExtensions
{
  public static IServiceCollection LoadServices(this IServiceCollection services, ConfigurationManager configuration)
  {
    services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(configuration.GetConnectionString("Default")));
    services.AddCors(options =>
    {
      options.AddDefaultPolicy(builder =>
      {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
      });
    });

    services.AddScoped<ITokenService, TokenService>();
    services.AddSingleton<IConfiguration>(configuration);
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IMovieRepository, MovieRepository>();
    services.AddEndpointsApiExplorer();
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    return services;
  }
}