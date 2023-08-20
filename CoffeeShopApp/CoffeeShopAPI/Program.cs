using API.Services;
using DataAccess.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

AuthenticationBuilder authenticationBuilder = builder.Services.AddAuthentication("Bearer");
authenticationBuilder.AddIdentityServerAuthentication("Bearer", options =>
{
    options.Authority = "https://localhost:5443";
    options.ApiName = "CoffeeShopAPI";
});

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<ICoffeeShopService, CoffeeShopService>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();