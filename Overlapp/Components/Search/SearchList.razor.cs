using Microsoft.AspNetCore.Components;
using Overlapp.Shared.Model;

namespace Overlapp.Components
{
	public partial class SearchList : ComponentBase
	{

		[Parameter]
		public string SearchTerm { get; set; } = string.Empty;
		[Parameter]
		public int PageNumber { get; set; } = 1;

		[Parameter]
		public Func<string, int, Task<SearchMultiResponse>> GetDataAsync { get; set; } = async (search, page) => { await Task.CompletedTask; return new SearchMultiResponse(0, new SearchMultiRecord[0], 0, 0); };

		public EventCallback<IMediaRecord> SelectClicked { get; set; }
		public EventCallback<IMediaRecord> RemoveClicked { get; set; }

		private SearchMultiResponse Data { get; set; } = new SearchMultiResponse(0, new SearchMultiRecord[0], 0, 0);

		private async Task Search()
		{
			Data = await GetDataAsync(SearchTerm, PageNumber);
		}
	}
}