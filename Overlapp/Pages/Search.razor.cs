using Microsoft.AspNetCore.Components;
using Overlapp.Client;
using Overlapp.Client.Service;
using Overlapp.Service;
using Overlapp.Shared.Model;

namespace Overlapp.Pages
{
	public partial class Search : ComponentBase
	{
		[Inject]
		IQueryService? QueryService { get; set; }

		[Inject]
		ImageConfigurationService? ImageService { get; set; }

		[Inject]
		AppStateService? AppStateService { get; set; }

		[Parameter]
		public string searchTerm { get; set; } = string.Empty;

		public ImageConfiguration ImageConfiguration { get; set; }

		private async Task<SearchMultiResponse> FetchDataAsync(string searchTerm, int page = 1)
		{
			return await QueryService!.SearchMulti(searchTerm, page);
		}

		private async Task ItemSelected(IMediaRecord record)
		{
			if (AppStateService.Request.HasItem(record))
			{
				AppStateService.Request.RemoveRequest(record);
			}
			else
			{
				AppStateService.Request.AddRequest(record);
			}
		}

		protected async override Task OnInitializedAsync()
		{
			ImageConfiguration = await ImageService?.Configuration;
		}
	}
}