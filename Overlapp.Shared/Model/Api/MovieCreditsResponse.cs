namespace Overlapp.Shared.Model
{
	public record MovieCreditsResponse(MovieCreditRecordCast[] cast, MovieCreditRecordCrew[] crew, long id);
	public record MovieCreditRecordCast(bool adult, int gender, long id, string known_for_department, string name, string original_name, float popularity, string profile_path, int cast_id, string character, string credit_id, int order) : IPerson
	{
		public long Id => id;
		public string Name => name;
		public string Image => profile_path;
	}
	public record MovieCreditRecordCrew(bool adult, int gender, long id, string known_for_department, string name, string original_name, float popularity, string profile_path, string credit_id, string department, string job) : IPerson
	{
		public long Id => id;
		public string Name => name;
		public string Image => profile_path;
	}
}
