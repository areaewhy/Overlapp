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

		public async Task<CreditAggregate[]> CreditsGet(MediaContainer media)
		{
			switch (media.Media.MediaType)
			{
				case MediaType.Tv:
					if (media.SeasonId.HasValue && media.EpisodeId.HasValue)
					{
						// look up episode info
						throw new NotImplementedException("Episode Cast not yet implemented");
					}
					else if (media.SeasonId.HasValue)
					{
						// look up season cast
						throw new NotImplementedException("Season Cast not yet implemented");
					}
					else
					{
						return (await QueryService.TvCredits(media.Id)).ToAggregateCredits(media);
					}
				case MediaType.Movie:
					return (await QueryService.MovieCredits(media.Id)).ToAggregateCredits(media);
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
