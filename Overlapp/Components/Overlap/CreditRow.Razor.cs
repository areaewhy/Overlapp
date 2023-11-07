using Microsoft.AspNetCore.Components;
using Overlapp.Shared.Model;

namespace Overlapp.Components
{
	public partial class CreditRow : ComponentBase
	{
		[Parameter]
		public CreditAggregateGroup Credit { get; set; }

		[CascadingParameter]
		ImageConfiguration ImageConfiguration { get; set; }
	}
}