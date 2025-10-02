using DavesPortfolio.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient("PoliceApi", client =>
{
    client.BaseAddress = new Uri("https://data.police.uk/api/");
});

builder.Services.AddHttpClient("LocalApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7035/");
});
builder.Services.AddScoped<PoliceDataService>();


builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthenticationStateDeserialization();
builder.Services.AddMudServices();

await builder.Build().RunAsync();
