using Overlapp.Model;
using Overlapp.Shared.Model;

namespace Overlapp.Components
{
	internal class EmptyPagedResponse : IApiPagedResponse<SearchMultiRecord>
	{
		public int page { get; init; }
		public int total_pages { get; init; }
		public int total_results { get; init; }
		public SearchMultiRecord[] results { get; init; } = new SearchMultiRecord[0];
	}
}