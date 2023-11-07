using Microsoft.AspNetCore.Components;
using Overlapp.Client;
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

		[Inject]
		NavigationManager Navigate { get; set; }

		[Parameter]
		public string SearchTerm { get; set; } = string.Empty;

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

			if (AppStateService.Request.IsReady)
			{
				var ids = AppStateService.Request.Items.Select(m => MediaIdentity.ToIdentifier(m)).ToArray();
				Navigate.NavigateTo($"/overlap?ida={ids[0]}&idb={ids[1]}");
			}
		}

		protected async override Task OnInitializedAsync()
		{
			ImageConfiguration = await ImageService?.Configuration;
		}
	}
}