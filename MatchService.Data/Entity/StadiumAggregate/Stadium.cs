using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchService.Data.Entity.StadiumAggregate
{
    public class Stadium
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }

        public List<Sector> Sectors { get; set; }
    }
}
