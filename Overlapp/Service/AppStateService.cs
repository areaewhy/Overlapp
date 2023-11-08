using Overlapp.Client;
using Overlapp.Shared.Model;

namespace Overlapp.Service
{
	public class AppStateService
	{
		public OverlapRequest Request { get; private set; } = new OverlapRequest();
		public void OverrideRequest(OverlapRequest r)
		{
			Request = r;
		}
	}
}
