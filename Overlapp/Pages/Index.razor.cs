namespace Overlapp.Pages
{
	public partial class Index
	{

		protected override void OnInitialized()
		{
			//GoToSearch();
		}

		private void GoToSearch()
		{
			Navigation.NavigateTo("/search");
		}
	}
}