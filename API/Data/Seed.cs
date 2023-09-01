using System.Text.Json;
using API.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Data
{

  public static class Seed
  {

    public static async Task SeedUsers(UserManager<User> userManager)
    {
      if (!userManager.Users.Any())
      {
        // Seed your user data here
        var usersToSeed = JsonSerializer.Deserialize<List<User>>(File.ReadAllText("Data/users.json"));

        foreach (var user in usersToSeed)
        {
          await userManager.CreateAsync(user, "Pa$$w0rd");
          if(user.UserName.ToLower()=="david")
          await userManager.AddToRoleAsync(user,"Admin"); 
          else {await userManager.AddToRoleAsync(user,"User"); }
          
        }

      }

      
    }
  }
}