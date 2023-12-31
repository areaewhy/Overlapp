﻿using Overlapp.Shared.Model;
using Overlapp.Shared.Model.Api;
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

		public async Task<IApiPagedResponse<SearchMovieRecord>> SearchMovieTitle(string title, int page = 1)
		{
			// # https://developer.themoviedb.org/reference/search-movie

			string url = $"/3/search/movie?query={title}&page={page}";
			return await Get<SearchMovieResponse>(url);
		}


		public async Task<IApiPagedResponse<SearchTvRecord>> SearchTvTitle(string title, int page = 1)
		{
			// # https://developer.themoviedb.org/reference/search-tv
			string url = $"/3/search/tv?query={title}&page={page}";
			return await Get<SearchTvResponse>(url);
		}

		public async Task<TvAggregateCreditResponse> TvCredits(int series_id)
		{
			// # https://developer.themoviedb.org/reference/tv-series-aggregate-credits
			string url = $"/3/tv/{series_id}/aggregate_credits";
			return await Get<TvAggregateCreditResponse>(url);
		}

		public async Task<CreditDetailResponse> CreditDetails(string credit_id)
		{
			// # https://developer.themoviedb.org/reference/credit-details
			string url = $"3/credit/{credit_id}";
			return await Get<CreditDetailResponse>(url);
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


		public async Task<IApiPagedResponse<SearchMultiRecord>> SearchMulti(string search, int page = 1)
		{
			// # https://developer.themoviedb.org/reference/search-multi
			string url = $"/3/search/multi?query={search}&page={page}"; ;
			return await Get<SearchMultiResponse>(url);
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

		public async Task<SeasonDetailsResponse> TvSeasonDetail(int series_id, int season_number)
		{
			string url = $"/3/tv/{series_id}/season/{season_number}";
			return await Get<SeasonDetailsResponse>(url);
		}

		public async Task<EpisodeCreditsResponse> TvEpisodeCredits(int series_id, int season_number, int episode_number)
		{
			string url = $"/3/tv/{series_id}/season/{season_number}/episode/{episode_number}/credits";
			return await Get<EpisodeCreditsResponse>(url);
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
