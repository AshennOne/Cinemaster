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
        var usersToSeed = JsonSerializer.Deserialize<List<User>>(File.ReadAllText("data/users.json"));

        foreach (var user in usersToSeed)
        {
          await userManager.CreateAsync(user, "Pa$$w0rd"); // Change the password as needed
        }
      }
    }
  }
}