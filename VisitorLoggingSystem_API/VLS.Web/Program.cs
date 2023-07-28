using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VLS.Web;
using VLS.Web.Helpers.API;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
string apiDomain = builder.Configuration["AppSettings:APIDomain"];
builder.Services.AddScoped(x => new HttpClient { BaseAddress = new Uri(apiDomain) });

builder.Services.AddScoped<IBaseHttpClient, BaseHttpClient>();

await builder.Build().RunAsync();
