using Microsoft.AspNetCore.Components;
using Overlapp.Client;
using Overlapp.Service;
using Overlapp.Shared.Model;
using Overlapp.Shared.Model.Domain;

namespace Overlapp.Pages
{
	public partial class Overlap : ComponentBase
	{
		[Inject]
		NavigationManager Navigation { get; set; }

		[Inject]
		ComparisonService ComparisonService { get; set; }

		[Inject]
		public AppStateService AppState { get; set; }

		[Inject]
		public ImageConfigurationService ImageConfigurationService { get; set; }

		[Parameter]
		[SupplyParameterFromQuery]
		public string? ida { get; set; }

		[Parameter]
		[SupplyParameterFromQuery]
		public string? idb { get; set; }

		private ImageConfiguration ImageConfiguration;
	
		protected async override Task OnInitializedAsync()
		{
			ImageConfiguration = await ImageConfigurationService.Configuration;
		}

		protected async override Task OnParametersSetAsync()
		{
			if (AppState.Request.IsEmpty && !string.IsNullOrEmpty(ida) && !string.IsNullOrEmpty(idb))
			{
				var a = MediaIdentity.Parse(ida);
				var b = MediaIdentity.Parse(idb);

				var request = await ComparisonService.RequestBuild(a, b);
				
				AppState.OverrideRequest(request);
			}
		}

		private async Task<CreditAggregate[]> GetCreditOverlap()
		{
			if (AppState.Request.IsReady)
			{
				var results = await ComparisonService.ResponseBuild(AppState.Request);
				return results.Intersection;
			}

			return new CreditAggregate[0];
		}

		private async Task ItemRemove(MediaContainer record)
		{
			AppState.Request.RemoveRequest(record);
			Navigation.NavigateTo("/search");
		}

		private async Task ResetState()
		{
			AppState.Reset();
			Navigation.NavigateTo("/search");
		}
	}
}