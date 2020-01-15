using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchService.Data.Entity.MatchAggregate
{
    public class PlaceAtMatch
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int SectorNumber { get; set; }

        public Match Match{ get; set; }
    }
}
