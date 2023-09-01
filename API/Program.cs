using System.Collections;
using API.Extensions;
using API.Middlewares;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.LoadAuthServices(builder.Configuration);
builder.Services.LoadServices(builder.Configuration);

var app = builder.Build();


AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllers();
app.MapFallbackToController("Index","Fallback");

await app.UpdateDb();
await app.UseSeedingRoles();
await app.UseSeedingUsers();
app.Run();