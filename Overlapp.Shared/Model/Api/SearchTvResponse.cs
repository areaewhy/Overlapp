﻿namespace Overlapp.Shared.Model
{
	public record SearchTvResponse(int page,
		SearchTvRecord[] results,
		int total_pages,
		int total_results);

	public record SearchTvRecord(
		int adult,
		string backdrop_path,
		int[] genre_ids,
		long id,
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
		public long Id => id;
		public string Title => name;
		public MediaType MediaType => MediaType.Tv;
		public string Image => poster_path;
		public string Overview => overview;
		public DateTime ReleaseDate => DateTime.Parse(first_air_date);
	}
}
