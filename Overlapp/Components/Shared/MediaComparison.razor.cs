using Microsoft.AspNetCore.Components;
using Overlapp.Model;
using Overlapp.Shared.Model;

namespace Overlapp.Components
{
	public partial class MediaComparison
	{
		[Parameter]
		public IMediaRecord[] Data { get; set; } = new EmptyMediaRecord[2];

		[CascadingParameter]
		public ImageConfiguration ImageConfiguration { get; set; } = null!;

		[Parameter]
		public EventCallback<IMediaRecord> ItemRemoveClick { get; set; }

		[Parameter]
		public EventCallback<int> EmptySelected { get; set; }
	}
}