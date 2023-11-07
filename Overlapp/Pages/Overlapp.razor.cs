using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Overlapp.Pages
{
	public partial class Overlap : ComponentBase, IDisposable
	{
		[Inject]
		NavigationManager Navigation { get; set; }

		[SupplyParameterFromQuery]
		public string? ida { get; set; }

		[SupplyParameterFromQuery]
		public string? idb { get; set; }

		protected override void OnInitialized()
		{
			
		}

		void HandleLocationChanged(object? sender, LocationChangedEventArgs e)
		{
			StateHasChanged();

		}



		public async Task FetchData(int ida, int idb)
		{
			// do the intersection
		}


		public void Dispose()
		{
		}
	}
}