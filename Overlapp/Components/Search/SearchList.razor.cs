using Microsoft.AspNetCore.Components;
using Overlapp.Shared.Model;

namespace Overlapp.Components
{
	public partial class SearchList : ComponentBase
	{

		[Inject]
		public NavigationManager Navigation { get; set; }

		[Parameter]
		public string SearchTerm { get; set; } = string.Empty;
		[Parameter]
		public int PageNumber { get; set; } = 1;

		[Parameter]
		public Func<string, int, Task<SearchMultiResponse>> GetDataAsync { get; set; } = async (search, page) => { await Task.CompletedTask; return new SearchMultiResponse(0, new SearchMultiRecord[0], 0, 0); };

		[Parameter]
		public EventCallback<IMediaRecord> SelectClicked { get; set; }

		private bool IsBusy = true;

		private SearchMultiResponse Data { get; set; } = new SearchMultiResponse(0, new SearchMultiRecord[0], 0, 0);

		protected async override Task OnParametersSetAsync()
		{
			if (string.IsNullOrEmpty(SearchTerm))
			{
				IsBusy = false;
				return;
			}

			IsBusy = true;
			Data = await GetDataAsync(SearchTerm, PageNumber);
			IsBusy = false;
		}

		private void Route()
		{
			Navigation.NavigateTo($"/search/{SearchTerm}");
		}
	}
}