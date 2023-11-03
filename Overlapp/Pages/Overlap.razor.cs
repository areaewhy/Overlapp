using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Overlapp.Pages
{
	public partial class Overlap : ComponentBase, IDisposable
	{
		[Inject]
		NavigationManager Navigation { get; set; }


		int? ida;
		int? idb;

		protected override void OnInitialized()
		{
			GetQueryStringValues();
			Navigation.LocationChanged += HandleLocationChanged;
		}

		void HandleLocationChanged(object? sender, LocationChangedEventArgs e)
		{
			GetQueryStringValues();
			StateHasChanged();

		}

		void GetQueryStringValues()
		{
			// kinda yucky!
			var uri = Navigation.ToAbsoluteUri(Navigation.Uri);
			var pieces = uri.Query.Replace("?","").Split('&');
			var parsed = pieces.Select(t => t.Split("=")).Where(x => x.Count() == 2).ToDictionary(k => k[0].ToLower(), v => v[1]);
			if (parsed.TryGetValue(nameof(ida), out var a) && int.TryParse(a, out var ai))
			{
				ida = ai;
			}
			if (parsed.TryGetValue(nameof(idb), out var b) && int.TryParse(a, out var bi))
			{
				idb = bi;
			}
		}


		public void Dispose()
		{
			Navigation.LocationChanged -= HandleLocationChanged;
		}
	}
}