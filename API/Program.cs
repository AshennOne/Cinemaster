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


 IConfiguration configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            // Retrieve the value of the environment variable
            string connectionString = configuration["ConnectionStrings__DefaultConnection"];

            Console.WriteLine($"Connection string: {connectionString}");
          connectionString=  builder.Configuration.GetConnectionString("DefaultConnection");
           Console.WriteLine($"Connection string: {connectionString}");

await app.UpdateDb();
await app.UseSeedingRoles();
await app.UseSeedingUsers();
app.Run();