namespace Overlapp.Shared.Model
{
	public struct MediaIdentity
	{
		public MediaIdentity(IMediaRecord record)
		{
			MediaType = record.MediaType;
			Id = record.id;
		}
		public MediaType MediaType { get; init; } = MediaType.Unknown;
		public int Id { get; init; }

		public bool IsValid => Id != 0;

		public override string ToString() => ToIdentifier(MediaType, Id);

		public static string ToIdentifier(MediaType t, int id) => $"{t.ToString()[0]}{id}";

		public static string ToIdentifier(IMediaRecord r) => ToIdentifier(r.MediaType, r.id);

		public static MediaIdentity Create(IMediaRecord record)
		{
			return new MediaIdentity(record);
		}

		// todo: add tests
		public static MediaIdentity Create(string id)
		{
			if (string.IsNullOrWhiteSpace(id) || id.Length < 2)
				return new MediaIdentity();

			char[] eligibleStartCharacters = Enum.GetNames<MediaType>().Select(n => n[0]).ToArray();

			char media_short = id[0];
			if (!eligibleStartCharacters.Any(c => Equals(c, media_short)))
				return new MediaIdentity();

			MediaType t = Enum.GetValues<MediaType>().Where(e => e.ToString()[0] == media_short).FirstOrDefault();

			if (int.TryParse(id.Substring(1), out int num))
			{
				return new MediaIdentity()
				{
					Id = num,
					MediaType = t
				};
			}

			return new MediaIdentity();
		}
	}
}
