using BoardGameAssistant.Client.Services;
using BoardGameAssistant.ServiceContracts.Common;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddMudServices();

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthenticationStateDeserialization();

builder.Services.AddScoped<IPlayerNameProvider, WasmPlayerNameProvider>();

await builder.Build().RunAsync();
