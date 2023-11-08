using Overlapp.Shared.Model.Domain;
using System.Linq;

namespace Overlapp.Shared.Model
{
	public enum MediaType { Unknown, Movie, Tv }

	public record SearchMovieResponse(int page, SearchMovieRecord[] results, int total_pages, int total_results);
	public record SearchMovieRecord(bool adult, string backdrop_path, int[] genre_ids, int id, string original_language, string original_title, string overview, float popularity, string poster_path, string release_date, string title, bool video, float vote_average, int vote_count) : IMediaRecord
	{
		public string NameOrTitle => title;
		public MediaType MediaType => MediaType.Movie;
		public string Image => poster_path;
		public string MediaOverview => overview;
		public DateTime? ReleaseDate => DateTime.TryParse(release_date, out var d) ? d : null;
	}

	public interface IMediaRecord
	{
		string NameOrTitle { get; }
		MediaType MediaType { get; }
		string Image { get; }
		DateTime? ReleaseDate { get; }
		string MediaOverview { get; }
		int id { get; }
	}
}
