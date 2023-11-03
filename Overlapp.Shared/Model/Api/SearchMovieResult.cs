namespace Overlapp.Shared.Model
{
	public enum MediaType { Unknown, Movie, Tv }

	public record SearchMovieResponse(int page, SearchMovieRecord[] results, int total_pages, int total_results);
	public record SearchMovieRecord(bool adult, string backdrop_path, int[] genre_ids, long id, string original_language, string original_title, string overview, float popularity, string poster_path, string release_date, string title, bool video, float vote_average, int vote_count) : IMediaRecord
	{
		public long Id => id;

		public string Title => title;
		public MediaType MediaType => MediaType.Movie;
		public string Image => poster_path;
		public string Overview => overview;
		public DateTime ReleaseDate => DateTime.Parse(release_date);
	}

	public interface IMediaRecord
	{
		string Title { get; }
		MediaType MediaType { get; }
		string Image { get; }
		DateTime ReleaseDate { get; }
		string Overview { get; }
		long Id { get; }
	}
}
