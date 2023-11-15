using Microsoft.AspNetCore.Components;
using Overlapp.Model;
using Overlapp.Shared.Model;

namespace Overlapp.Components
{
	public partial class MediaComparison
	{
		[Parameter]
		public MediaContainer[] Data { get; set; } = new MediaContainer[2];

		[CascadingParameter]
		public ImageConfiguration ImageConfiguration { get; set; } = null!;

		[Parameter]
		public EventCallback<MediaContainer> ItemRemoveClick { get; set; }

		[Parameter]
		public EventCallback<int> EmptySelected { get; set; }
	}
}