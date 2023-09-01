using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Middlewares
{
  public static class SeedingMiddleware
  {
    public async static Task UpdateDb(this WebApplication app)
    {
       using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var dbContext = services.GetRequiredService<ApplicationDbContext>();
            
            await dbContext.Database.MigrateAsync();
        }
    }
    public async static Task UseSeedingRoles(this WebApplication app)
    {
      using (var scope = app.Services.CreateScope())
      {
        var RoleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
        var roles = new[] { "Admin", "User" };
        foreach (var role in roles)
        {
          
            await RoleManager.CreateAsync(new IdentityRole<int>(role));
          
        }

      }
    }
    public async static Task UseSeedingUsers(this WebApplication app)
    {
      using (var scope = app.Services.CreateScope())
      {
        var services = scope.ServiceProvider;
        //var context = services./GetRequiredService<ApplicationDbContext>();
        //context.Database.Migrate();
        var userMgr = services.GetRequiredService<UserManager<User>>();
        await Seed.SeedUsers(userMgr);
      }
    }
  }
}