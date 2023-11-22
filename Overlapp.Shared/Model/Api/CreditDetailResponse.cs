namespace Overlapp.Shared.Model.Api
{
	public record CreditDetailResponse(string credit_type, string department, string job, CreditDetailMedia media, string media_type, string id, PersonCredit person);

	public record PersonCredit(bool adult, int id, string name, string original_name, string media_type, float popularity, int gender, string known_for_department, string profile_path) : IPerson
	{
		public string PersonName => name;

		public string? Image => profile_path;
	}

	public record CreditDetailMedia(bool adult, string backdrop_path, int id, string name, string original_language, string original_name, string overview, string poster_path, string media_type, int[] genre_ids, float popularity, string first_air_date, float vote_average, int vote_count, string[] origin_country, string character, Episode[] episodes) : IMediaRecord
	{
		public string NameOrTitle => name;

		public MediaType MediaType => MediaType.Parse<MediaType>(media_type);

		public string Image => poster_path;

		public DateTime? ReleaseDate => DateTime.TryParse(first_air_date, out var d) ? d : null;

		public string MediaOverview => overview;
	}
}
