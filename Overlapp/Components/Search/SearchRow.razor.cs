using Microsoft.AspNetCore.Components;
using Overlapp.Client.Service;
using Overlapp.Shared.Model;

namespace Overlapp.Components
{
	public partial class SearchRow : ComponentBase
	{
		[Parameter]
		public IMediaRecord? Media { get; set; } = null;

		[CascadingParameter]
		public ImageConfiguration ImageConfiguration { get; set; }

		[Inject]
		public ImageConfigurationService? ImageService { get; set; }

		public string ImagePath(string not_found)
		{
			if (ImageConfiguration != null && Media != null)
			{
				return ImageConfiguration.MakeImage(Media);
			}

			return not_found;
		}

	}
}