namespace Overlapp.Shared.Model
{
	public class OverlapRequest
	{
		private int Setter = -1;

		public OverlapRequest() { }
		public OverlapRequest(IMediaRecord a, IMediaRecord b)
		{
			Items = new IMediaRecord[] { a, b };
		}

		public IMediaRecord?[] Items = new IMediaRecord[2]; // Capping at 2 items to intersect... 

		public bool AddRequest(IMediaRecord r)
		{
			// No changes if this item is already present.
			if (HasItem(r))
				return false;

			Setter = ++Setter % 2;
			Items[Setter] = r;

			return true;
		}

		public bool RemoveRequest(IMediaRecord r)
		{
			for (var i = 0; i < Items.Length; i++)
			{
				if (Items[i]?.id == r.id)
				{
					Items[i] = null;
					Setter = i - 1;
					return true;
				}
			}

			// item was not in the array, nothing changed
			return false;
		}

		public bool IsReady => !Items.Any(a => a == null);
		public bool IsEmpty => Items.All(a => a == null);
		public bool HasItem(IMediaRecord r)
		{
			return Items.Any(a => a != null && a.id == r.id);
		}
	}
}
