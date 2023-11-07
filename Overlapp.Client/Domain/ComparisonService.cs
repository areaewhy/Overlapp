using Overlapp.Shared.Model;
using Overlapp.Shared.Model.Domain;

namespace Overlapp.Client
{
	public class ComparisonService
	{
		private IQueryService QueryService;

		public ComparisonService(IQueryService queryService)
		{
			QueryService = queryService;
		}

		
		public async Task<OverlapRequest> RequestBuild(MediaIdentity a, MediaIdentity b)
		{
			var mediaA = await MediaDetail(a);
			var mediaB = await MediaDetail(b);

			return new OverlapRequest(mediaA, mediaB);
		}

		public async Task<OverlapResponse> ResponseBuild(OverlapRequest request)
		{
			var credits = await Task.WhenAll(request.Items.Where(p => p != null).Select(async i => await CreditsGet(i)));

			return new OverlapResponse(request.Items, credits.FindIntersection());					
		}

		public async Task<CreditAggregate[]> CreditsGet(IMediaRecord media)
		{
			switch (media.MediaType)
			{
				case MediaType.Tv:
					return (await QueryService.TvCredits(media.id)).ToAggregateCredits(media);
				case MediaType.Movie:
					return (await QueryService.MovieCredits(media.id)).ToAggregateCredits(media);
			}

			throw new Exception("Invalid credit request");
		}


		public async Task<IMediaRecord> MediaDetail(MediaIdentity media)
		{
			switch (media.MediaType)
			{
				case MediaType.Tv:
					return await QueryService.TvDetail(media.Id);
				case MediaType.Movie:
					return await QueryService.MovieDetail(media.Id);
			}

			return null;
			//throw new Exception("Invalid Detail Request");
		}
	}
}
