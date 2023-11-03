namespace Overlapp.Shared.Model
{
	public record SearchMultiResponse(int page, SearchMultiRecord[] results, int total_pages, int total_results);
	public record SearchMultiRecord(bool adult, string backdrop_path, long id, string title, string original_language, string original_title, string overview, string poster_path, string media_type, int[] genre_ids, float popularity, string release_date, bool video, float vote_average, int vote_count) : IMediaRecord
	{
		public long Id => id;
		public string Title => title;
		public MediaType MediaType => Enum.TryParse<MediaType>(media_type, out var t) ? t : MediaType.Unknown;
		public string Image => poster_path;
		public string Overview => overview;
		public DateTime ReleaseDate => DateTime.Parse(release_date);
	}
}
