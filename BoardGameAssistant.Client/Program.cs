using BoardGameAssistant.Client.Services;
using BoardGameAssistant.ServiceContracts.Common;
using BoardGameAssistant.ServiceContracts.Scythe;
using BoardGameAssistant.ServiceContracts.Wingspan;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddMudServices();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthenticationStateDeserialization();

builder.Services.AddScoped<IPlayerNameProvider, WasmPlayerNameProvider>();
builder.Services.AddScoped<IWingspanGameService, WasmWingspanGameService>();
builder.Services.AddScoped<IScytheGameService, WasmScytheGameService>();
builder.Services.AddSingleton<TitleMenuService, TitleMenuService>();

await builder.Build().RunAsync();
