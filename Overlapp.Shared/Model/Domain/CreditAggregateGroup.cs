namespace Overlapp.Shared.Model
{
	public class CreditAggregateGroup : CreditGroupBase
	{
		public CreditAggregateGroup(IEnumerable<CreditAggregate> credits) : base(credits)
		{
			Departments = credits.GroupBy(c => c.Department).Select(d => new CreditGroupDepartment(d));
		}

		public IEnumerable<CreditGroupDepartment> Departments { get; init; }
	}

	public class CreditGroupDepartment : CreditGroupBase
	{
		public CreditGroupDepartment(IEnumerable<CreditAggregate> credits) : base(credits)
		{
			Films = credits.GroupBy(f => f.Item).Select(film => new CreditGroupFilm(film.ToArray())).ToArray();
		}
		public IEnumerable<CreditGroupFilm> Films { get; init; }
	}

	public class CreditGroupFilm : CreditGroupBase
	{
		public CreditGroupFilm(IEnumerable<CreditAggregate> credits) : base(credits)
		{
			Characters = credits;
		}

		public IEnumerable<CreditAggregate> Characters { get; init; }
	}

	public abstract class CreditGroupBase
	{
		public CreditGroupBase(IEnumerable<CreditAggregate> credits)
		{
			Representative = credits.First();
		}

		public CreditAggregate Representative { get; init; }
	}
}
