namespace Overlapp.Shared.Model
{
	public record SearchMultiResponse(int page, SearchMultiRecord[] results, int total_pages, int total_results);
	public record SearchMultiRecord(bool adult, string backdrop_path, long id, string name, string title, string original_language, string original_title, string original_name, string overview, string poster_path, string media_type, int[] genre_ids, float popularity, string first_air_date, string release_date, bool video, float vote_average, int vote_count) : IMediaRecord
	{
		public long Id => id;
		public string Title => IsTv ? name : title;
		public MediaType MediaType => Enum.TryParse<MediaType>(media_type, out var t) ? t : MediaType.Unknown;
		public string Image => poster_path;
		public string Overview => overview;
		private bool IsTv => MediaType == MediaType.Tv;
		public DateTime ReleaseDate => DateTime.Parse(IsTv ? first_air_date : release_date);
	}
}
