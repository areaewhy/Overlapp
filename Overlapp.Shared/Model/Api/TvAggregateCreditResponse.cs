using Overlapp.Shared.Model;

namespace Overlapp.Shared.Model
{
	public record TvAggregateCreditResponse(TvAggregateCreditRecordCast[] cast, TvAggregateCreditRecordCrew[] crew, long id);
	public record TvAggregateCreditRecordCast(bool adult, int gender, long id, string known_for_department, string name, string original_name, float popularity, string profile_path, CastRole[] roles, int total_episode_count, int order) : IPerson
	{
		public long Id => id;
		public string Name => name;
		public string Image => profile_path;
	}
	public record TvAggregateCreditRecordCrew(bool adult, int gender, long id, string known_for_department, string name, string original_name, float popularity, string profile_path, CrewJob[] jobs, string department, int total_episode_count) : IPerson
	{
		public long Id => id;
		public string Name => name;
		public string Image => profile_path;
	}

	public record CrewJob(string credit_id, string job, int episode_count);
	public record CastRole(string credit_id, string character, int episode_count);

	public interface IPerson
	{
		long Id { get; }
		string Name { get; }
		string Image { get; }

	}
}
