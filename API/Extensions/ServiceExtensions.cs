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
    var host = configuration["POSTGRESQL_ADDON_HOST"];
    var port =configuration["POSTGRESQL_ADDON_PORT"];
    var userId = configuration["POSTGRESQL_ADDON_USER"];
    var password = configuration["POSTGRESQL_ADDON_PASSWORD"];
    var database = configuration["POSTGRESQL_ADDON_DB"];
    var DefaultConnection= $"Server={host}; Port={port}; User Id={userId}; Password={password}; Database={database}";
    services.AddDbContext<ApplicationDbContext>(o =>
    {
      
      o.UseNpgsql(DefaultConnection);
    });
    services.AddCors(options =>
    {
      options.AddDefaultPolicy(builder =>
      {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
      });
    });
    services.AddHttpClient();
    services.AddScoped<ITokenService, TokenService>();
    services.AddSingleton<IConfiguration>(configuration);
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IMovieRepository, MovieRepository>();
    services.AddEndpointsApiExplorer();
    services.AddScoped<IRatingRepository, RatingsRepository>();
    services.AddScoped<ICommentRepository, CommentRepository>();
    services.AddScoped<IMovieListRepository, MovieListRepository>();
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    services.AddScoped<IUnitOfWork, UnitOfWork>();

    return services;
  }
}