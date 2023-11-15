using Microsoft.AspNetCore.Components;
using Overlapp.Model;
using Overlapp.Shared.Model;

namespace Overlapp.Components
{
	public partial class SearchList : ComponentBase
	{

		[Inject]
		public NavigationManager Navigation { get; set; } = null!;

		[Parameter]
		public string SearchTerm { get; set; } = string.Empty;
		[Parameter]
		public int PageNumber { get; set; } = 1;

		[Parameter]
		public Func<string, int, Task<IApiPagedResponse<SearchMultiRecord>>> GetDataAsync { get; set; } = null!;

		[Parameter]
		public EventCallback<MediaContainer> SelectClicked { get; set; }

		private bool IsBusy = true;
		private string? _searchTerm;

		private IApiPagedResponse<SearchMultiRecord>? Data { get; set; } = new EmptyPagedResponse();

		protected async override Task OnParametersSetAsync()
		{
			if (string.IsNullOrEmpty(SearchTerm) || _searchTerm == SearchTerm)
			{
				IsBusy = false;
				return;
			}

			IsBusy = true;
			Data = await GetDataAsync(SearchTerm, PageNumber);
			_searchTerm = SearchTerm;
			IsBusy = false;
		}

		private void Route(string term = "")
		{
			Data = new EmptyPagedResponse();
			Navigation.NavigateTo($"/search/{term}");
		}
	}
}