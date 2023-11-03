using System.Runtime.CompilerServices;

namespace Overlapp.Client.Utility
{
	public class AsyncLazy<T> : Lazy<Task<T>>
	{
		public AsyncLazy(Func<T> value) : base(() => Task.Factory.StartNew(value))
		{

		}

		public AsyncLazy(Func<Task<T>> value) :
			base(() => Task.Factory.StartNew(() => value()).Unwrap())
		{ }

		public TaskAwaiter<T> GetAwaiter() { return Value.GetAwaiter(); }
	}
}
