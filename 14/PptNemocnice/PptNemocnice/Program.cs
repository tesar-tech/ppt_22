using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PptNemocnice;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
var apiUri = builder.Configuration["ApiUri"];
if(apiUri == null) throw new ArgumentNullException(nameof(apiUri));
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUri) });

await builder.Build().RunAsync();

