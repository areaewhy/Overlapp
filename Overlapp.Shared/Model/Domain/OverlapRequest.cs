using Overlapp.Shared.Model.Domain;

namespace Overlapp.Shared.Model
{
	public class OverlapRequest
	{
		private int Setter = -1;

		public OverlapRequest() { }
		public OverlapRequest(IMediaRecord a, IMediaRecord b) : this(new MediaContainer(a), new(b))
		{
		}

		public OverlapRequest(MediaContainer a, MediaContainer b)
		{
			Items = new MediaContainer[] { a, b };
		}

		public MediaContainer?[] Items = new MediaContainer[2]; // Capping at 2 items to intersect... 

		public bool AddRequest(IMediaRecord a, int? index)
		{
			return AddRequest(new MediaContainer(a), index);
		}

		public bool AddRequest(MediaContainer r, int? index)
		{
			// No changes if this item is already present.
			if (HasItem(r))
				return false;

			if (index != null)
			{
				Setter = index.Value % 2;
			}
			else
			{
				Setter = ++Setter % 2;
			}
			
			Items[Setter] = r;

			return true;
		}

		public bool RemoveRequest(MediaContainer r)
		{
			for (var i = 0; i < Items.Length; i++)
			{
				if (Items[i] == r)
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

		public bool HasItem(MediaContainer m)
		{
			return Items.Any(a => a != null && a == m);
		}
		public bool HasItem(IMediaRecord r)
		{
			return Items.Any(a => a?.Media != null && a.Media == r);
		}

	}
}
