using Microsoft.AspNetCore.Components;

namespace Overlapp.Pages
{
	public partial class Search
	{

		[Parameter]
		public string Title { get; set; } = string.Empty;
	}
}