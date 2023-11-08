using Overlapp.Shared.Model;

namespace Overlapp.Model
{
	internal record EmptyMediaRecord(string NameOrTitle = "", MediaType MediaType = MediaType.Unknown, string Image = "", DateTime? ReleaseDate = null, string MediaOverview = "", int id = 0 ) : IMediaRecord;
}