using System.Text;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions;

public static class AuthServiceExtensions
{
  public static IServiceCollection LoadAuthServices(this IServiceCollection services, ConfigurationManager configuration)
  {
    services.AddIdentityCore<User>(opt =>
      {
        opt.Password.RequireNonAlphanumeric = false;
        opt.Password.RequireDigit = false;
      }).AddRoles<IdentityRole<int>>().AddRoleManager<RoleManager<IdentityRole<int>>>().AddEntityFrameworkStores<ApplicationDbContext>();
    services.AddAuthentication(options =>
    {
      options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
        .AddJwtBearer(options =>
        {
          options.TokenValidationParameters = new TokenValidationParameters
          {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Key"])),
            ValidateIssuer = false,
            ValidateAudience = false,
            RequireExpirationTime = true
          };
        });
    return services;
  }
}