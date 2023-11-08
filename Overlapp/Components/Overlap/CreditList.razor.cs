using Microsoft.AspNetCore.Components;
using Overlapp.Shared.Model;

namespace Overlapp.Components
{
	public partial class CreditList : ComponentBase
	{
		[Parameter]
		public Func<Task<CreditAggregate[]>> FetchCredits { get; set; } = null!;

		CreditAggregate[]? Data { get; set; }
		bool IsBusy { get; set; }

		protected async override Task OnParametersSetAsync()
		{
			IsBusy = true;
			Data = await FetchCredits();
			IsBusy = false;
		}

	}
}