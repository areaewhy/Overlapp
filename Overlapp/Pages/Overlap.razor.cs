using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Overlapp.Client;
using Overlapp.Shared.Model;

namespace Overlapp.Pages
{
	public partial class Overlap : ComponentBase
	{
		[Inject]
		NavigationManager Navigation { get; set; }

		[Inject]
		QueryService QueryService { get; set; }

		[SupplyParameterFromQuery]
		public string? ida { get; set; }

		[SupplyParameterFromQuery]
		public string? idb { get; set; }

		private IMediaRecord MediaA;
		private IMediaRecord MediaB;

		protected async override Task OnParametersSetAsync()
		{
			var recordA = MediaIdentity.Create(ida);
			var recordB = MediaIdentity.Create(idb);

			
		}

		private async Task<IMediaRecord> GetDetails(MediaIdentity id)
		{
			if (id.MediaType == MediaType.Tv)
			{
				await QueryService.TvDetail(id.Id);
			}

			return null;
		}



	}
}