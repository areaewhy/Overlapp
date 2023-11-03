namespace Overlapp.Shared.Model
{
		public record PersonCombinedCreditsResponse(PersonCombinedCreditsRecordCast[] cast, PersonCombinedCreditsRecordCrew[] crew, long id);
		public record PersonCombinedCreditsRecordCast(bool adult, string backdrop_path, int[] genre_ids, long id, string original_language, string original_title, string overview, float popularity, string poster_path, string release_date, string title, bool video, float vote_average, int vote_count, string character, string credit_id, int order, string media_type) : IMediaRecord
	{
		public long Id => id;
		public string Title => title;
		public MediaType MediaType => Enum.TryParse<MediaType>(media_type, out var t) ? t : MediaType.Unknown;
		public string Image => poster_path;
		public string Overview => overview;
		public DateTime ReleaseDate => DateTime.Parse(release_date);
	}

	public record PersonCombinedCreditsRecordCrew(bool adult, string backdrop_path, int[] genre_ids, long id, string original_language, string original_title, string overview, float popularity, string poster_path, string release_date, string title, bool video, float vote_average, int vote_count, string credit_id, string department, string job, string media_type) : IMediaRecord
	{
		public long Id => id;
		public string Title => title;
		public MediaType MediaType => Enum.TryParse<MediaType>(media_type, out var t) ? t : MediaType.Unknown;
		public string Image => poster_path;
		public string Overview => overview;
		public DateTime ReleaseDate => DateTime.Parse(release_date);
	}
}
