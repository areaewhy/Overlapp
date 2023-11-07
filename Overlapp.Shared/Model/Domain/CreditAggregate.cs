using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overlapp.Shared.Model
{
	public record CreditAggregate(string Name, string CharacterOrJob, string Department, int id, string CreditId, int InstanceCount, float Popularity, string? Image, IMediaRecord? Item) : IPerson
	{
		public string PersonName => Name;
	}
}
