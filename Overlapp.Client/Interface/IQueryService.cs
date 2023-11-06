using Overlapp.Shared.Model;

namespace Overlapp.Client
{
	public interface IQueryService
	{
		Task<ImageConfiguration> GetImageConfiguration();
		Task<MovieCreditsResponse> GetMovieCredits(int movie_id);
		Task<PersonCombinedCreditsResponse> GetPersonCredits(int person_id);
		Task<TvAggregateCreditResponse> GetTvCredits(int series_id);
		Task<SearchMovieResponse> SearchMovieTitle(string title, int page = 1);
		Task<SearchMultiResponse> SearchMulti(string search, int page = 1);
		Task<SearchTvResponse> SearchTvTitle(string title, int page = 1);
	}
}