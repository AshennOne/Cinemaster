using API.Data;
using API.Entities;
using API.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.LoadAuthServices(builder.Configuration);
builder.Services.LoadServices(builder.Configuration);

var app = builder.Build();



app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using(var scope = app.Services.CreateScope()){
  var services = scope.ServiceProvider;
  var context = services.GetRequiredService<ApplicationDbContext>();
  context.Database.Migrate();
  var userMgr = services.GetRequiredService<UserManager<User>>();
  await Seed.SeedUsers(userMgr);
}
app.Run();