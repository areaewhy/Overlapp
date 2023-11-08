using Overlapp.Shared.Model;

namespace Overlapp.Client
{
	public interface IQueryService
	{
		Task<ImageConfiguration> GetImageConfiguration();
		Task<MovieCreditsResponse> MovieCredits(int movie_id);
		Task<PersonCombinedCreditsResponse> GetPersonCredits(int person_id);
		Task<TvAggregateCreditResponse> TvCredits(int series_id);
		Task<IApiPagedResponse<IMediaRecord>> SearchMovieTitle(string title, int page = 1);
		Task<IApiPagedResponse<IMediaRecord>> SearchMulti(string search, int page = 1);
		Task<IApiPagedResponse<IMediaRecord>> SearchTvTitle(string title, int page = 1);

		Task<MovieDetailsResponse> MovieDetail(int movie_id);
		Task<TvDetailsResponse> TvDetail(int series_id);
	}
}