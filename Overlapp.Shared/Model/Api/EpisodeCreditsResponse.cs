using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overlapp.Shared.Model.Api
{
	public record EpisodeCreditsResponse(CreditRecordCast[] cast, CreditRecordCrew[] crew, CreditRecordCast[] guest_stars, int id);
}
