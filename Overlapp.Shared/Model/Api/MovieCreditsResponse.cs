namespace Overlapp.Shared.Model
{
	public record MovieCreditsResponse(MovieCreditRecordCast[] cast, MovieCreditRecordCrew[] crew, int id);
	public record MovieCreditRecordCast(bool adult, int gender, int id, string known_for_department, string name, string original_name, float popularity, string profile_path, int cast_id, string character, string credit_id, int order) : IPerson
	{
		public string PersonName => name;
		public string Image => profile_path;
	}
	public record MovieCreditRecordCrew(bool adult, int gender, int id, string known_for_department, string name, string original_name, float popularity, string profile_path, string credit_id, string department, string job) : IPerson
	{
		public string PersonName => name;
		public string Image => profile_path;
	}
}
