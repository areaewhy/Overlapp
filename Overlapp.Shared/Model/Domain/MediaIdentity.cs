using System.Globalization;

namespace Overlapp.Shared.Model
{
	public struct MediaIdentity
	{
		public MediaIdentity(MediaContainer record)
		{
			MediaType = record.Media.MediaType;
			Id = record.Media.id;
			Season = record.SeasonId;
			Episode = record.EpisodeId;
		}
		public MediaType MediaType { get; init; } = MediaType.Unknown;
		public int Id { get; init; }
		public int? Season { get; init; }
		public int? Episode { get; init; }

		public bool IsValid => Id != 0;

		public override string ToString() => ToIdentifier(MediaType, Id, Season, Episode);

		public static string ToIdentifier(MediaType t, int id, int? season, int? episode) => $"{t.ToString()[0]}{MakeRequired(id)}{MakeOptional(season)}{MakeOptional(episode)}";

		private static Func<int?, string> MakeRequired = (val) => $"{val}";
		private static Func<int?, string> MakeOptional = (val) => MakePiece(val, '-');
		private static Func<int?, char, string> MakePiece = (val, sep) => val.HasValue ? $"{sep}{val.Value}" : "";

		public static string ToIdentifier(MediaContainer r) => ToIdentifier(r.Media.MediaType, r.Media.id, r.SeasonId, r.EpisodeId);

		public static MediaIdentity Create(MediaContainer record)
		{
			return new MediaIdentity(record);
		}

		// todo: add tests
		public static MediaIdentity Parse(string id)
		{
			if (string.IsNullOrWhiteSpace(id) || id.Length < 2)
				return new MediaIdentity();

			// getting first character of MediaTypes
			char[] eligibleStartCharacters = Enum.GetNames<MediaType>().Select(n => n[0]).ToArray();
			
			// given the first character, does it exist in the [] above?
			char media_short = id[0];
			if (!eligibleStartCharacters.Any(c => Equals(c, media_short)))
				return new MediaIdentity();

			// if so, find the MediaType
			MediaType t = Enum.GetValues<MediaType>().Where(e => e.ToString()[0] == media_short).FirstOrDefault();

			// split into array of [ id, seasonId, episodeId ], based on separator in <cref MakeOptional>
			string[] chunks = id.Substring(1).Split('-');
			
			// helper to 1) make sure the index is valid, and 2) make sure it's a number!
			Func<string[], int, int?> GetPiece = (parts, ix) =>
			{
				if (ix < parts.Length && int.TryParse(parts[ix], out var num))
				{
					return num;
				}

				return null;
			};

			// it has at least Id!
			if (chunks.Length > 0)
			{
				return new MediaIdentity()
				{
					Id = GetPiece(chunks, 0)!.Value,
					Season = GetPiece(chunks, 1),
					Episode = GetPiece(chunks, 2),
					MediaType = t,
				};
			}

			return new MediaIdentity();
		}
	}
}
