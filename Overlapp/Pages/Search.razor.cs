using Microsoft.AspNetCore.Components;
using Overlapp.Client;
using Overlapp.Shared.Model;

namespace Overlapp.Pages
{
	public partial class Search : ComponentBase
	{
		[Inject]
		IQueryService? QueryService { get; set; }


		[Parameter]
		public string searchTerm { get; set; } = string.Empty;

		private async Task<SearchMultiResponse> FetchDataAsync(string searchTerm, int page = 1)
		{
			return await QueryService!.SearchMulti(searchTerm, page);
		}
	}
}