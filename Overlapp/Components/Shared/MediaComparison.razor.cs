using Microsoft.AspNetCore.Components;
using Overlapp.Shared.Model;

namespace Overlapp.Components
{
	public partial class MediaComparison
	{
		[Parameter]
		public IMediaRecord[] Data { get; set; }

		[CascadingParameter]
		public ImageConfiguration ImageConfiguration { get; set; }

		[Parameter]
		public EventCallback<IMediaRecord> ItemRemoveClick { get; set; }
	}
}