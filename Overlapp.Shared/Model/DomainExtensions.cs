namespace Overlapp.Shared.Model.Domain
{
	public static class DomainExtensions
	{
		public static CreditAggregate[] ToAggregateCredits(this TvAggregateCreditResponse credits, IMediaRecord media)
		{
			var crew = credits.crew.SelectMany(c => c.jobs.Select(j => new CreditAggregate(
				Name: c.Name,
				CharacterOrJob: j.job,
				Department: "crew",
				Id: c.id,
				CreditId: j.credit_id,
				InstanceCount: c.total_episode_count,
				Popularity: c.popularity,
				Image: c.Image,
				Item: media))).ToArray();

			var cast = credits.cast.SelectMany(c => c.roles.Select(r => new CreditAggregate(
				Name: c.Name,
				CharacterOrJob: r.character,
				Department: "actor",
				Id: c.Id,
				CreditId: r.credit_id,
				InstanceCount: c.total_episode_count,
				Popularity: c.popularity,
				Image: c.Image,
				Item: media))).ToArray();

			return Merge(crew, cast);
		}

		public static CreditAggregate[] ToAggregateCredits(this MovieCreditsResponse credits, IMediaRecord media)
		{
			var crew = credits.crew.Select(c => new CreditAggregate(
				Name: c.Name,
				CharacterOrJob: c.job,
				Department: c.department,
				Id: c.Id,
				CreditId: c.credit_id,
				InstanceCount: 1,
				Popularity: c.popularity,
				Image: c.Image,
				Item: media)).ToArray();

			var cast = credits.cast.Select(c => new CreditAggregate(
				Name: c.Name,
				CharacterOrJob: c.character,
				Department: "actor",
				Id: c.Id,
				CreditId: c.credit_id,
				InstanceCount: 1,
				Popularity: c.popularity,
				Image: c.Image,
				Item: media)).ToArray();

			return Merge(crew, cast);
		}

		public static CreditAggregate[] FindIntersection(this IEnumerable<CreditAggregate[]> credits)
		{
			var collections = credits.Select(a => a.GroupBy(k => k.Id).Select(a => a.Key).ToHashSet()).ToArray();

			int j = 0;
			while (j < collections.Length - 1)
			{
				collections[0] = collections[0].Intersect(collections[++j]).ToHashSet();
			}

			var consolidatedCredits = credits.SelectMany(t => t.Where(m => collections[0].Contains(m.Id)));
			var intersection = consolidatedCredits.OrderBy(a => a.Department).ThenByDescending(t => t.InstanceCount).ToArray();

			return intersection;
		}

		/// <summary>
		/// Concatenate two arrays
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="A"></param>
		/// <param name="B"></param>
		/// <returns></returns>
		private static T[] Merge<T>(T[] A, T[] B)
		{
			var x = new T[A.Count() + B.Count()];
			A.CopyTo(x, 0);
			B.CopyTo(x, A.Length);

			return x;
		}
	}
}
