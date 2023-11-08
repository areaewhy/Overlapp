namespace Overlapp.Shared.Model
{
	public interface IApiPagedResponse<T>
	{
		int page { get; init; }
		int total_pages { get; init; }
		int total_results { get; init; }
		T[] results { get; init; }
	}
}
