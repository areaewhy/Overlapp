using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overlapp.Shared.Model
{
	public record CreditAggregate(string Name, string CharacterOrJob, string Department, long Id, string CreditId, int InstanceCount, float Popularity, string? Image, IMediaRecord? Item);
}
