using Microsoft.AspNetCore.Components;
using Overlapp.Shared.Model;

namespace Overlapp.Components
{
	public partial class SearchRow : ComponentBase
	{
		[Parameter]
		public IMediaRecord? Media { get; set; } = null;

		public string WORD { get; } = "HI";
	}
}