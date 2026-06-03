using InventorySystem.Web;
using InventorySystem.Web.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// MudBlazor services for the mordern UI components
builder.Services.AddMudServices();

// Configure the HTTP client to point to your ASP.Net core API
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7082/api/")
});

builder.Services.AddScoped<ProductApiService>();

await builder.Build().RunAsync();