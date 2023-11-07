using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Overlapp.Client;
using Overlapp.Shared.Model;
using Overlapp.Shared.Model.Domain;

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

		public IMediaRecord MediaA { get; set; }
		public IMediaRecord MediaB { get; set; }

		protected async override Task OnParametersSetAsync()
		{
			var recordA = MediaIdentity.Create(ida);
			var recordB = MediaIdentity.Create(idb);

			var (mediaA, crewA) = await GetDetails(recordA);
			var (mediaB, crewB) = await GetDetails(recordB);
		}

		private async Task<CreditAggregate[]> Overlap(IMediaRecord a, IMediaRecord b)
		{
			return null;
		}

		private async Task<(IMediaRecord, CreditAggregate[])> GetDetails(MediaIdentity id)
		{
			if (!id.IsValid)
			{
				await Task.CompletedTask;
				// invalid id...  todo: better handling
				throw new Exception("Invalid Parameter");
			}

			switch (id.MediaType)
			{
				case MediaType.Tv:
					var tvDetail = await QueryService.TvDetail(id.Id);
					var tvCast = await QueryService.TvCredits(id.Id);
					return (tvDetail, tvCast.ToAggregateCredits(tvDetail));
				case MediaType.Movie:
					var movieDetail = await QueryService.MovieDetail(id.Id);
					var movieCast = await QueryService.MovieCredits(id.Id);
					return (movieDetail, movieCast.ToAggregateCredits(movieDetail));
			}

			throw new Exception("Invalid Parameter");

		}



	}
}