using Overlapp.Client.Utility;
using Overlapp.Shared.Model;

namespace Overlapp.Client.Service
{
	public class ImageConfigurationService
	{
		public ImageConfigurationService(IQueryService queryService)
		{
			Configuration = new AsyncLazy<ImageConfiguration>(async () => await queryService.GetImageConfiguration());
		}

		public AsyncLazy<ImageConfiguration> Configuration;
	}
}
