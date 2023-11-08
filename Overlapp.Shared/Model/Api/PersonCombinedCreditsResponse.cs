namespace Overlapp.Shared.Model
{
		public record PersonCombinedCreditsResponse(PersonCombinedCreditsRecordCast[] cast, PersonCombinedCreditsRecordCrew[] crew, int id);
		public record PersonCombinedCreditsRecordCast(bool adult, string backdrop_path, int[] genre_ids, int id, string original_language, string original_title, string overview, float popularity, string poster_path, string release_date, string title, bool video, float vote_average, int vote_count, string character, string credit_id, int order, string media_type) : IMediaRecord
	{
		public string NameOrTitle => title;
		public MediaType MediaType => Enum.TryParse<MediaType>(media_type, out var t) ? t : MediaType.Unknown;
		public string Image => poster_path;
		public string MediaOverview => overview;
		public DateTime? ReleaseDate => DateTime.TryParse(release_date, out var d) ? d : null;
	}

	public record PersonCombinedCreditsRecordCrew(bool adult, string backdrop_path, int[] genre_ids, int id, string original_language, string original_title, string overview, float popularity, string poster_path, string release_date, string title, bool video, float vote_average, int vote_count, string credit_id, string department, string job, string media_type) : IMediaRecord
	{
		public string NameOrTitle => title;
		public MediaType MediaType => Enum.TryParse<MediaType>(media_type, out var t) ? t : MediaType.Unknown;
		public string Image => poster_path;
		public string MediaOverview => overview;
		public DateTime? ReleaseDate => DateTime.TryParse(release_date, out var d) ? d : null;
	}
}
