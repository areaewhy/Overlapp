using Overlapp.Shared.Model;
using System.Net.Http.Json;
using System.Text.Json;

namespace Overlapp.Client
{
	public class QueryService : IQueryService
	{
		private readonly HttpClient Http;
		private readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions() { AllowTrailingCommas = true, PropertyNameCaseInsensitive = true };

		public QueryService(HttpClient http)
		{
			Http = http;
		}

		public async Task<IApiPagedResponse<IMediaRecord>> SearchMovieTitle(string title, int page = 1)
		{
			// # https://developer.themoviedb.org/reference/search-movie

			string url = $"/3/search/movie?query={title}&page={page}";
			return (IApiPagedResponse<IMediaRecord>)await Get<SearchMovieResponse>(url);
		}


		public async Task<IApiPagedResponse<IMediaRecord>> SearchTvTitle(string title, int page = 1)
		{
			// # https://developer.themoviedb.org/reference/search-tv
			string url = $"/3/search/tv?query={title}&page={page}";
			return (IApiPagedResponse<IMediaRecord>)await Get<SearchTvResponse>(url);
		}

		public async Task<TvAggregateCreditResponse> TvCredits(int series_id)
		{
			// # https://developer.themoviedb.org/reference/tv-series-aggregate-credits
			string url = $"/3/tv/{series_id}/aggregate_credits";
			return await Get<TvAggregateCreditResponse>(url);
		}


		public async Task<MovieCreditsResponse> MovieCredits(int movie_id)
		{
			// # https://developer.themoviedb.org/reference/movie-credits
			string url = $"/3/movie/{movie_id}/credits";
			return await Get<MovieCreditsResponse>(url);
		}


		public async Task<PersonCombinedCreditsResponse> GetPersonCredits(int person_id)
		{
			// # https://developer.themoviedb.org/reference/person-combined-credits
			string url = $"/3/person/{person_id}/combined_credits";
			return await Get<PersonCombinedCreditsResponse>(url);
		}


		public async Task<IApiPagedResponse<IMediaRecord>> SearchMulti(string search, int page = 1)
		{
			// # https://developer.themoviedb.org/reference/search-multi
			string url = $"/3/search/multi?query={search}&page={page}"; ;
			return (IApiPagedResponse<IMediaRecord>)await Get<SearchMultiResponse>(url);
		}

		public async Task<MovieDetailsResponse> MovieDetail(int movie_id)
		{
			// # https://developer.themoviedb.org/reference/movie-details
			string url = $"/3/movie/{movie_id}";
			return await Get<MovieDetailsResponse>(url);
		}

		public async Task<TvDetailsResponse> TvDetail(int series_id)
		{
			// # https://developer.themoviedb.org/reference/tv-series-details
			string url = $"/3/tv/{series_id}";
			return await Get<TvDetailsResponse>(url);
		}

		public async Task<ImageConfiguration> GetImageConfiguration()
		{
			string url = "/3/configuration";
			return await Get<ImageConfiguration>(url);
		}


		private async Task<T> Get<T>(string url)
		{
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
			var response = await Http.SendAsync(request);
			// todo: make a more meaningful exception if Json can't serialize.
			return await response.Content.ReadFromJsonAsync<T>(SerializerOptions) ?? throw new ApiResultNullException();
		}
	}
}
