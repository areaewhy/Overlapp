using Microsoft.AspNetCore.Components;
using Overlapp.Client;
using Overlapp.Model;
using Overlapp.Service;
using Overlapp.Shared.Model;

namespace Overlapp.Components
{
	public partial class SearchRow : ComponentBase
	{
		[Parameter]
		public IMediaRecord Media { get; set; } = new EmptyMediaRecord();

		[CascadingParameter]
		public ImageConfiguration ImageConfiguration { get; set; }

		[Inject]
		public ImageConfigurationService? ImageService { get; set; }

		[Inject]
		public AppStateService State { get; set; }

		[Parameter]
		public EventCallback<IMediaRecord> SelectedClick { get; set; }

		public string ImagePath(string not_found)
		{
			if (ImageConfiguration != null && Media != null)
			{
				return ImageConfiguration.MakeImage(Media) ?? not_found;
			}

			return not_found;
		}

		public bool AlreadyAdded => State.Request.HasItem(Media);

	}
}