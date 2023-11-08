namespace Overlapp.Shared.Model
{
	public record SearchTvResponse(int page,
		SearchTvRecord[] results,
		int total_pages,
		int total_results);

	public record SearchTvRecord(
		int adult,
		string backdrop_path,
		int[] genre_ids,
		int id,
		string[] origin_country,
		string original_language,
		string original_name,
		string overview,
		string popularity,
		string poster_path,
		string first_air_date,
		string name,
		float vote_average,
		int vote_count) : IMediaRecord
	{
		public int id => id;
		public string NameOrTitle => name;
		public MediaType MediaType => MediaType.Tv;
		public string Image => poster_path;
		public string MediaOverview => overview;
		public DateTime? ReleaseDate => DateTime.TryParse(first_air_date, out var d) ? d : null;
	}
}
