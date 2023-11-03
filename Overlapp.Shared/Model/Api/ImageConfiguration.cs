using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overlapp.Shared.Model
{
	public record ImageSizes(string base_url, string secure_base_url, string[] backdrop_sizes, string[] logo_sizes, string[] poster_sizes, string[] profile_sizes, string[] still_sizes, string[] change_keys);
	public record ImageConfiguration(ImageSizes images)
	{
		internal string ImageRootUrl => images.base_url;
	}
}
