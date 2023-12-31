using Client.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();

IConfigurationSection identityServerSettings = builder.Configuration.GetSection("IdentityServerSettings");
builder.Services.Configure<IdentityServerSettings>(identityServerSettings);
builder.Services.AddScoped<ITokenService, TokenService>();

SetAuthenticationBuilder(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();











static void SetAuthenticationBuilder(WebApplicationBuilder builder)
{
    AuthenticationBuilder authenticationBuilder = builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    });

    authenticationBuilder.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);

    authenticationBuilder.AddOpenIdConnect(
        OpenIdConnectDefaults.AuthenticationScheme,
        options =>
        {
            options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.SignOutScheme = OpenIdConnectDefaults.AuthenticationScheme;
            options.Authority = builder.Configuration["InteractiveServiceSettings:AuthorityUrl"];
            options.ClientId = builder.Configuration["InteractiveServiceSettings:ClientId"];
            options.ClientSecret = builder.Configuration["InteractiveServiceSettings:ClientSecret"];

            options.ResponseType = "code";
            options.SaveTokens = true;
            options.GetClaimsFromUserInfoEndpoint = true;
        }
    );
}