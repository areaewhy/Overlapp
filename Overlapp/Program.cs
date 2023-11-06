using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Overlapp;
using Overlapp.Client;
using Overlapp.Service;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("TMDBApi", client =>
{
	client.BaseAddress = new Uri("https://api.themoviedb.org/");
}).AddHttpMessageHandler<TMDBAuthHandler>();

builder.Services.AddTransient(h =>
	new TMDBAuthHandler(builder.Configuration.GetValue<string>("TMDB_KEY"))
);

builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("TMDBApi"));

builder.Services.AddOverlappServices();

builder.Services.AddScoped<AppStateService>();

await builder.Build().RunAsync();
