using Overlapp.Shared.Model;
using Overlapp.Shared.Model.Api;

namespace Overlapp.Client
{
	public interface IQueryService
	{
		Task<ImageConfiguration> GetImageConfiguration();
		Task<MovieCreditsResponse> MovieCredits(int movie_id);
		Task<PersonCombinedCreditsResponse> GetPersonCredits(int person_id);
		Task<TvAggregateCreditResponse> TvCredits(int series_id);
		Task<IApiPagedResponse<SearchMovieRecord>> SearchMovieTitle(string title, int page = 1);
		Task<IApiPagedResponse<SearchMultiRecord>> SearchMulti(string search, int page = 1);
		Task<IApiPagedResponse<SearchTvRecord>> SearchTvTitle(string title, int page = 1);

		Task<MovieDetailsResponse> MovieDetail(int movie_id);
		Task<TvDetailsResponse> TvDetail(int series_id);
		Task<SeasonDetailsResponse> TvSeasonDetail(int series_id, int season_number);
		Task<EpisodeCreditsResponse> TvEpisodeCredits(int series_id, int season_number, int episode_number);
		Task<CreditDetailResponse> CreditDetails(string credit_id);
	}
}