using API.Data;
using API.Entities;
using API.Extensions;
using API.Middlewares;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.LoadAuthServices(builder.Configuration);
builder.Services.LoadServices(builder.Configuration);

var app = builder.Build();



app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.UseSeedingRoles();
await app.UseSeedingUsers();
app.Run();