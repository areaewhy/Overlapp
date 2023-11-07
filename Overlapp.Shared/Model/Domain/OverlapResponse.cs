namespace Overlapp.Shared.Model
{
	public record OverlapResponse(IMediaRecord?[] Items, CreditAggregate[] Intersection);
}
