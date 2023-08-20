using IdentityServer;
using IdentityServer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var seed = args.Contains("/seed");
if (seed) args = args.Except(new[] { "/seed" }).ToArray();

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly.GetName().Name;
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (seed) SeedData.EnsureSeedData(connectionString);

builder.Services.AddDbContext<AspNetIdentityDbContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly(assembly)));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AspNetIdentityDbContext>();

SetIdentityserver(builder, assembly, connectionString);

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();

app.UseIdentityServer();

//app.UseAuthorization();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapDefaultControllerRoute();
//});

app.Run();





static void SetIdentityserver(WebApplicationBuilder builder, string? assembly, string connectionString)
{
    IIdentityServerBuilder identityServer = builder.Services.AddIdentityServer();
    identityServer.AddAspNetIdentity<IdentityUser>();
    identityServer.AddConfigurationStore(options =>
    {
        options.ConfigureDbContext = b => b.UseSqlServer(connectionString, opt => opt.MigrationsAssembly(assembly));
    });
    identityServer.AddOperationalStore(options =>
    {
        options.ConfigureDbContext = b =>
        b.UseSqlServer(connectionString, opt => opt.MigrationsAssembly(assembly));
    });
    identityServer.AddDeveloperSigningCredential();
}