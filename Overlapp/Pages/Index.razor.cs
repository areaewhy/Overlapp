namespace Overlapp.Pages
{
	public partial class Index
	{

		protected override void OnInitialized()
		{
			//GoToSearch();
		}

		private string SearchTerm { get; set; } = string.Empty;
		private void GoToSearch()
		{
			Navigation.NavigateTo($"/search/{SearchTerm}");
		}
	}
}