using Distribuidora.WEB;
using Distribuidora.WEB.Repositories;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IRepository, Repository>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7171/") });

await builder.Build().RunAsync();
