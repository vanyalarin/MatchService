using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchService.Data.Entity.StadiumAggregate
{
    public class Place
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public decimal PriceMultiplier { get; set; }

        public Sector Sector { get; set; }
    }
}
