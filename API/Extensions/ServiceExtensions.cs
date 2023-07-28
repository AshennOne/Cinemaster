using API.Data;
using API.Data.Repositories;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ServiceExtensions
{
  public static IServiceCollection LoadServices(this IServiceCollection services)
  {
    services.AddCors(options =>
{
  options.AddPolicy("AllowAngularApp",
  builder => builder.WithOrigins("http://localhost:4200")
    .AllowAnyHeader()
    .AllowAnyMethod());
});
    services.AddIdentity<User, IdentityRole<int>>(opt =>
       {
         opt.Password.RequireNonAlphanumeric = false;
       })
         .AddEntityFrameworkStores<ApplicationDbContext>()
         .AddDefaultTokenProviders();
    services.AddScoped<IUserRepository,UserRepository>();
    return services;
  }
}