using Overlapp.Shared.Model.Api;

namespace Overlapp.Shared.Model.Domain
{
	public static class DomainExtensions
	{

		public static CreditAggregate[] ToAggregateCredits(this EpisodeCreditsResponse credits, MediaContainer media)
		{
			var cast = CreditConvert(credits.cast, media);
			var crew = CreditConvert(credits.crew, media);
			var guest = CreditConvert(credits.guest_stars, media);

			return Merge(cast, crew, guest);
		}

		/// <summary>
		/// Note: this will only give actors as GUESTS
		/// </summary>
		/// <param name="credits"></param>
		/// <param name="media"></param>
		/// <returns></returns>
		public static CreditAggregate[] ToAggregateCredits(this SeasonDetailsResponse credits, MediaContainer media)
		{
			var crew = credits.episodes.SelectMany(c => CreditConvert(c.crew, media)).ToArray();
			var guests = credits.episodes.SelectMany(c => CreditConvert(c.guest_stars, media)).ToArray();

			return Merge(crew, guests);
		}
		public static CreditAggregate[] ToAggregateCredits(this TvAggregateCreditResponse credits, MediaContainer media)
		{
			var crew = credits.crew.SelectMany(c => c.jobs.Select(j => new CreditAggregate(
				Name: c.PersonName,
				CharacterOrJob: j.job,
				Department: "crew",
				id: c.id,
				CreditId: j.credit_id,
				InstanceCount: c.total_episode_count,
				Popularity: c.popularity,
				Image: c.Image,
				Item: media))).ToArray();

			var cast = credits.cast.SelectMany(c => c.roles.Select(r => new CreditAggregate(
				Name: c.PersonName,
				CharacterOrJob: r.character,
				Department: "actor",
				id: c.id,
				CreditId: r.credit_id,
				InstanceCount: c.total_episode_count,
				Popularity: c.popularity,
				Image: c.Image,
				Item: media))).ToArray();

			return Merge(crew, cast);
		}

		public static CreditAggregate[] ToAggregateCredits(this MovieCreditsResponse credits, MediaContainer media)
		{
			var crew = CreditConvert(credits.crew, media);
			var cast = CreditConvert(credits.cast, media);

			return Merge(crew, cast);
		}

		public static CreditAggregate[] FindIntersection(this IEnumerable<CreditAggregate[]> credits)
		{
			var collections = credits.Select(a => a.GroupBy(k => k.id).Select(a => a.Key).ToHashSet()).ToArray();

			int j = 0;
			while (j < collections.Length - 1)
			{
				collections[0] = collections[0].Intersect(collections[++j]).ToHashSet();
			}

			var consolidatedCredits = credits
				.SelectMany(t => t.Where(m => collections[0].Contains(m.id)));

			var intersection = consolidatedCredits
				.OrderBy(f => f.Item?.Id)
				.ThenBy(a => a.Department)
				.ThenByDescending(t => t.InstanceCount)
				.ToArray();

			return intersection;
		}


		private static CreditAggregate[] CreditConvert(CreditRecordCrew[] crew, MediaContainer media)
		{
			return crew.Select(c => new CreditAggregate(
						Name: c.PersonName,
						CharacterOrJob: c.job,
						Department: c.department,
						id: c.id,
						CreditId: c.credit_id,
						InstanceCount: 1,
						Popularity: c.popularity,
						Image: c.Image,
						Item: media
						)).ToArray();
		}
		private static CreditAggregate[] CreditConvert(CreditRecordCast[] cast, MediaContainer media)
		{
			return cast.Select(c => new CreditAggregate(
				Name: c.PersonName,
				CharacterOrJob: c.character,
				Department: "actor",
				id: c.id,
				CreditId: c.credit_id,
				InstanceCount: 1,
				Popularity: c.popularity,
				Image: c.Image,
				Item: media)).ToArray();
		}


		/// <summary>
		/// Concatenate two arrays
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="A"></param>
		/// <param name="B"></param>
		/// <returns></returns>
		//private static T[] Merge<T>(T[] A, T[] B)
		//{
		//	var x = new T[A.Count() + B.Count()];
		//	A.CopyTo(x, 0);
		//	B.CopyTo(x, A.Length);

		//	return x;
		//}

		private static T[] Merge<T>(params T[][] collections)
		{
			var x = new T[collections.Sum(c => c.Length)];
			int position = 0;
			for(int i = 0; i < collections.Length; i++)
			{
				collections[i].CopyTo(x, position);
				position += collections[i].Length;
			}

			return x;
		}



	}
}
