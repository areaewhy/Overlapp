using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Http;
using Overlapp;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddHttpClient(client => new HttpClient()
//{
//	BaseAddress = new Uri("https://api.themoviedb.org/")
//});

builder.Services.AddHttpClient("TMDBApi", client =>
{
	client.BaseAddress = new Uri("https://api.themoviedb.org/");
}).AddHttpMessageHandler<TMDBAuthHandler>();

builder.Services.AddTransient(h =>
	new TMDBAuthHandler(builder.Configuration.GetValue<string>("TMDB_KEY"))
);

builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("TMDBApi"));

await builder.Build().RunAsync();


public class TMDBAuthHandler : DelegatingHandler
{
	private string Token;
	public TMDBAuthHandler(string token)
	{
		Token = token;
	}

	protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

		return base.SendAsync(request, cancellationToken);
	}
}