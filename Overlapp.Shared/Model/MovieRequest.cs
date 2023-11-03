using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overlapp.Shared.Model.Deprecated
{
		// movie search
		//public record SearchMovieResults(int page, int total_pages, int total_results, SearchResult[] results);
		//public record MovieResult
		//	(bool adult, string backdrop_path, int[] genre_ids, int id, string original_language, string original_title, string overview, float popularity, string poster_path, string release_date, string title, bool video, float vote_average, float vote_count);

		// configuration
		
		//public record QueryRequest
		//{
			
		//}

		//public record QueryResult(SearchResult[] Items, CreditAggregate[] Intersection);

	//	public record ImageSizes(string base_url, string secure_base_url, string[] backdrop_sizes, string[] logo_sizes, string[] poster_sizes, string[] profile_sizes, string[] still_sizes, string[] change_keys);



	//	//// todo: movie credits for person
	//	////https://developer.themoviedb.org/reference/person-movie-credits
	//	//public record PersonCast(bool adult, string backdrop_path, int[] genre_ids, int id, string original_language, string original_title, string overview, float popularity, string poster_path, string release_date, string title, bool video, float vote_average, float vote_count, string character, string credit_id, int order);
	//	//public record PersonCrew(bool adult, string backdrop_path, int[] genre_ids, int id, string original_language, string original_title, string overview, float popularity, string poster_path, string release_date, string title, bool video, float vote_average, float vote_count, string credit_id, string department, string job);
	//	//public record PersonCredit(PersonCast[] cast, PersonCrew[] crew, int id);

	//	// combined person person credits
	//	// https://developer.themoviedb.org/reference/person-combined-credits
	//	public record PersonCast(string character, string credit_id, int order) : MediaBase, ICast;
	//	public record PersonCrew(string credit_id, string department, string job) : MediaBase, ICrew;
	//	public record PersonCombinedCredits(PersonCast[] cast, PersonCrew[] crew, int id);


	//	// tv series aggregate credits
	//	// https://developer.themoviedb.org/reference/tv-series-aggregate-credits
	//	public record CreditCast(int total_episode_count, CastRole[] roles) : CreditBase;
	//	public record CreditCrew(int total_episode_count, CrewJob[] jobs) : CreditBase;

		

	//	public record TvCreditAggregate(int id, CreditCast[] cast, CreditCrew[] crew);


	//	// todo: movie credits for movie
	//	// https://developer.themoviedb.org/reference/movie-credits
	//	public record MovieCrew(string credit_id, string department, string job) : CreditBase, ICrew;
	//	public record MovieCast(int cast_id, string character, string credit_id, int order) : CreditBase, ICast;
	//	public record MovieCredits(int id, MovieCrew[] crew, MovieCast[] cast);


	//public record CreditAggregate
	//	{
	//		public CreditAggregate(MovieCrew crew, IMediaRecord media)
	//		{
	//			this.name = crew.name;
	//			this.character = crew.job;
	//			this.role = crew.department;
	//			this.id = crew.id;
	//			this.credit_id = crew.credit_id;
	//			this.profile_path = crew.profile_path;
	//			this.popularity = crew.popularity;
	//			this.Item = media;
	//		}

	//		public CreditAggregate(MovieCast cast, SearchResult media)
	//		{
	//			this.name = cast.name;
	//			this.character = cast.character;
	//			this.role = "actor";
	//			this.id = cast.id;
	//			this.credit_id = cast.credit_id;
	//			this.profile_path = cast.profile_path;
	//			this.popularity = cast.popularity;
	//			this.Item = media;
	//		}

	//		public CreditAggregate(CreditCast cast, CastRole role, SearchResult media)
	//		{
	//			this.name = cast.name;
	//			this.character = role.character;
	//			this.role = "actor";
	//			this.id = cast.id;
	//			this.credit_id = role.credit_id;
	//			instanceCount = role.episode_count;
	//			this.profile_path = cast.profile_path;
	//			this.popularity = cast.popularity;
	//			this.Item = media;
	//		}

	//		public CreditAggregate(CreditCrew cast, CrewJob role, SearchResult media)
	//		{
	//			this.name = cast.name;
	//			this.character = role.job;
	//			this.role = "crew";
	//			this.id = cast.id;
	//			this.credit_id = role.credit_id;
	//			instanceCount = role.episode_count;
	//			this.profile_path = cast.profile_path;
	//			this.popularity = cast.popularity;
	//			this.Item = media;
	//		}

	//		public string name;
	//		public string role;
	//		public string character;
	//		public int id;
	//		public string credit_id;
	//		public int instanceCount;
	//		public string profile_path;
	//		public float popularity;
	//		public SearchResult Item;
	//	}

	//	public record SearchModel
	//	{
	//		public enum SearchTypes
	//		{
	//			Movie, Tv //, Person

	//		}

	//		[Required]
	//		[StringLength(maximumLength: 3, ErrorMessage = "Search term is too short.")]
	//		public string? Term;
	//		public int Page;
	//		public SearchTypes Type;
	//	}

	//	public record CreditBase
	//	{
	//		public bool adult { get; init; }
	//		//string credit_id { get; init; }
	//		//string department { get; init; }
	//		public int gender { get; init; }
	//		public int id { get; init; }
	//		//string job { get; init; }
	//		public string known_for_department { get; init; }
	//		public string name { get; init; }
	//		public string original_name { get; init; }
	//		public float popularity { get; init; }
	//		public string profile_path { get; init; }
	//	}

	//	//public enum MediaType
	//	//{
	//	//	Unknown, Movie, Tv, Person
	//	//}

	//	public record MediaBase
	//	{	
	//		public bool adult { get; init; }
	//		public string backdrop_path { get; init; }
	//		public int id { get; init; }

	//		public string name { get; init; }
	//		public string original_name { get; init; }
	//		public string title { get; init; }
	//		public string original_language { get; init; }
	//		public string original_title { get; init; }
	//		public string overview { get; init; }
	//		public string poster_path { get; init; }
	//		public string media_type { get; init; } // todo... this ought to just come back from search, but doesn't.
	//		public int[] genre_ids { get; init; }
	//		public float popularity { get; init; }
	//		public string first_air_date { get; init; }
	//		public string release_date { get; init; }
	//		public bool video { get; init; }
	//		public float vote_average { get; init; }
	//		public int vote_count { get; init; }

	//		public MediaType Type => Enum.TryParse<MediaType>(media_type, out var mt) ? mt : MediaType.Unknown;

	//	}

	//	public interface ICast
	//	{
	//		public string character { get; init; }
	//		public string credit_id { get; init; }
	//		public int order { get; init; }
	//	}
	//	public interface ICrew
	//	{
	//		public string credit_id { get; init; }
	//		public string department { get; init; }
	//		public string job { get; init; }
	//	}

	#region MODELS_TWO



	#endregion
}
