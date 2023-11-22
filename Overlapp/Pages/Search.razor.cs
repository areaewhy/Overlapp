using Microsoft.AspNetCore.Components;
using Overlapp.Client;
using Overlapp.Service;
using Overlapp.Shared.Model;

namespace Overlapp.Pages
{
	public partial class Search : ComponentBase
	{
		[Inject]
		IQueryService QueryService { get; set; } = null!;

		[Inject]
		ImageConfigurationService ImageService { get; set; } = null!;

		[Inject]
		AppStateService AppState { get; set; } = null!;

		[Inject]
		NavigationManager Navigate { get; set; } = null!;

		[Parameter]
		public string SearchTerm { get; set; } = string.Empty;

		int? FillingNumber { get; set; }

		public ImageConfiguration ImageConfiguration { get; set; } = null!;

		private async Task<IApiPagedResponse<SearchMultiRecord>> FetchDataAsync(string searchTerm, int page = 1)
		{
			return await QueryService!.SearchMulti(searchTerm, page);
		}

		private async Task EmptySelected(int index)
		{
			FillingNumber = index;
		}

		private void ItemSelected(MediaContainer record)
		{
			if (AppState.Request.HasItem(record))
			{
				AppState.Request.RemoveRequest(record);
			}
			else
			{
				AppState.Request.AddRequest(record, FillingNumber);
			}

			SelectionMade();
			
		}

		private void SelectionMade()
		{
			if (AppState.Request.IsReady)
			{
				var ids = AppState.Request.Items.Select(m => MediaIdentity.ToIdentifier(m)).ToArray();
				Navigate.NavigateTo($"/overlap?ida={ids[0]}&idb={ids[1]}");
			}

			FillingNumber = null;
		}

		protected async override Task OnInitializedAsync()
		{
			ImageConfiguration = await ImageService.Configuration;
			if (AppState.Request.IsEmpty && !string.IsNullOrEmpty(SearchTerm))
			{
				FillingNumber = 0;
			}
		}

		private void ItemRemove(MediaContainer record)
		{
			AppState.Request.RemoveRequest(record);
		}

		private async Task<TvDetailsResponse> FetchTvDetails(int series_id)
		{
			return await QueryService.TvDetail(series_id);
		}

		private void OnEpisodeSelected((IMediaRecord media, int season, int episode) selected)
		{
			var target = new MediaContainer(selected.media)
			{
				EpisodeId = selected.episode,
				SeasonId = selected.season
			};

			AppState.Request.AddRequest(target, FillingNumber);

			SelectionMade();
		}
	}
}