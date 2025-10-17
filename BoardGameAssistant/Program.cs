using BoardGameAssistant.Client.Pages;
using BoardGameAssistant.Client.Services;
using BoardGameAssistant.Components;
using BoardGameAssistant.Components.Account;
using BoardGameAssistant.Data.App;
using BoardGameAssistant.Data.Scythe;
using BoardGameAssistant.Data.Wingspan;
using BoardGameAssistant.Entities;
using BoardGameAssistant.ServiceContracts.Common;
using BoardGameAssistant.ServiceContracts.Scythe;
using BoardGameAssistant.ServiceContracts.Wingspan;
using BoardGameAssistant.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MudBlazor.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Pøidejte služby lokalizace
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

// (Volitelné) Nastavení podporovaných kultur
var supportedCultures = new[] { new CultureInfo("en"), new CultureInfo("cs") };
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("cs");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents()
    .AddAuthenticationStateSerialization();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();
builder.Services.AddAuthorization();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<ScytheDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<WingspanDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.User.RequireUniqueEmail = true;
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@";

    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 3;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
builder.Services.AddScoped<IPlayerNameProvider, ServerPlayerNameProvider>();
builder.Services.AddScoped<IWingspanGameService, ServerWingspanGameService>();
builder.Services.AddScoped<IScytheGameService, ServerScytheGameService>();
builder.Services.AddScoped<IDateTimeProvider, DateTimeProvider>();
builder.Services.AddScoped<TitleMenuService, TitleMenuService>();

builder.Services.AddControllers();

var app = builder.Build();

// (Volitelné) Použijte lokalizaci v pipeline
var locOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(locOptions.Value);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BoardGameAssistant.Client._Imports).Assembly);

app.MapControllers();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
