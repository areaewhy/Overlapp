using Microsoft.AspNetCore.Components;
using Overlapp.Client;
using Overlapp.Client.Service;
using Overlapp.Shared.Model;

namespace Overlapp.Pages
{
	public partial class Search : ComponentBase
	{
		[Inject]
		IQueryService? QueryService { get; set; }

		[Inject]
		ImageConfigurationService? ImageService { get; set; }

		[Parameter]
		public string searchTerm { get; set; } = string.Empty;

		public ImageConfiguration ImageConfiguration { get; set; }

		private async Task<SearchMultiResponse> FetchDataAsync(string searchTerm, int page = 1)
		{
			return await QueryService!.SearchMulti(searchTerm, page);
		}

		protected async override Task OnInitializedAsync()
		{
			ImageConfiguration = await ImageService?.Configuration;
		}
	}
}