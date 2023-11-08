namespace Overlapp.Shared.Model
{
	public record TvDetailsResponse(bool adult, string backdrop_path, CreatedBy[] created_by, int[] episode_run_time, string first_air_date, Genre[] genres, string homepage, int id, bool in_production, string[] languages, string last_air_date, Episode last_episode_to_air, string name, string next_episode_to_air, Network[] networks, int number_of_episodes, int number_of_seasons, string[] origin_country, string original_language, string overview, float popularity, string poster_path, ProductionCompany[] production_companies, ProductionCountry[] production_countries, Season[] seasons, SpokenLanguage[] spoken_languages, string status, string tagline, string type, float vote_average, int vote_count) : IMediaRecord
	{
		public string NameOrTitle => name;

		public MediaType MediaType => MediaType.Tv;

		public string Image => poster_path;

		public DateTime? ReleaseDate => DateTime.TryParse(first_air_date, out var d) ? d : null;

		public string MediaOverview => overview;
	}

	public record CreatedBy(int id, string credit_id, string name, int gender, string profile_path);
	public record Episode(int id, string name, string overview, float vote_average, int vote_count, string air_date, int episode_number, string production_code, int runtime, int season_number, int show_id, string still_path);
	public record Network(int id, string logo_path, string name, string origin_country);
	public record Season(string air_date, int episode_count, int id, string name, string overview, string poster_path, int season_number, float vote_average);
}
