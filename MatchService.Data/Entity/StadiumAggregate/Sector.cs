using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchService.Data.Entity.StadiumAggregate
{
    public class Sector
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public decimal DefaultPrice { get; set; }

        public List<Place> Places { get; set; }
        public Stadium Stadium { get; set; }
    }
}
