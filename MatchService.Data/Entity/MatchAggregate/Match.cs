using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchService.Data.Entity.MatchAggregate
{
    public class Match
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public DateTime DateTime { get; set; }

        public List<PlaceAtMatch> PlaceAtMatches { get; set; }
        public int StadiumId { get; set; }
    }
}
