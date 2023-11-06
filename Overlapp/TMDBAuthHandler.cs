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