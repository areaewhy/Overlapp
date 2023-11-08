using System;

namespace Overlapp.Shared.Model
{
	public static class ApiExtensions
	{
		public static string? MakeImage(this ImageConfiguration config, IPerson? person)
		{
			if (string.IsNullOrEmpty(person?.Image))
			{
				return null;
			}
		
			return	$"{config.ImageRootUrl}{config.images.profile_sizes.Skip(1).FirstOrDefault()}{person.Image}";
		}

		public static string? MakeImage(this ImageConfiguration config, IMediaRecord? record)
		{

			if (string.IsNullOrEmpty(record?.Image))
			{
				return null;
			}

			return $"{config.ImageRootUrl}{config.images.poster_sizes.Skip(1).FirstOrDefault()}{record.Image}";
		}
	}
}
