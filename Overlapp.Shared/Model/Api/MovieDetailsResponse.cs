namespace Overlapp.Shared.Model
{
	public record MovieDetailsResponse(bool adult, string backdrop_path, int belongs_to_collection, decimal budget, Genre[] genres, string homepage, int id, string imdb_id, string original_language, string original_title, string overview, float popularity, string poster_path, ProductionCompany[] production_companies, ProductionCountry[] production_countries, string release_date, int revenu, int runtime, SpokenLanguage[] spoken_languages, string status, string title, bool video, float vote_average, int vote_count) : IMediaRecord
	{
		public string NameOrTitle => title;

		public MediaType MediaType => MediaType.Movie;

		public string Image => poster_path;

		public DateTime ReleaseDate => DateTime.Parse(release_date);

		public string MediaOverview => overview;
	}

	public record Genre(int id, string name);
	public record ProductionCompany(int id, string logo_path, string name, string origin_country);
	public record ProductionCountry(string iso_3166_1, string name);
	public record SpokenLanguage(string english_name, string iso_639_1, string name);

}
