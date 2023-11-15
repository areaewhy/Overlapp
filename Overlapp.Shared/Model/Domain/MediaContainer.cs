namespace Overlapp.Shared.Model
{
	public class MediaContainer
	{
		//public MediaContainer() { }
		public MediaContainer(IMediaRecord m) => Media = m;
		public IMediaRecord Media { get; init; }
		public int Id => Media.id;
		public int? SeasonId { get; set; }
		public int? EpisodeId { get; set; }

		public override int GetHashCode()
		{
			return (Media.id, SeasonId, EpisodeId).GetHashCode();
		}
	}
}
