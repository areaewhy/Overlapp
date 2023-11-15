using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overlapp.Shared.Model.Api
{
	public record SeasonDetailsResponse(string _id, string air_date, EpisodeWithCredits[] episodes, string name, string overview, int id, string poster_path, string season_number, string vote_average);

		public record EpisodeWithCredits(int id, string name, string overview, float vote_average, int vote_count, string air_date, int episode_number, string production_code, int runtime, int season_number, int show_id, string still_path, CreditRecordCrew[] crew, CreditRecordCast[] guest_stars);
}
