using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchService.Data.Entity.TicketAggregate
{
    public class PriceComponent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public Ticket Ticket { get; set; }
    }
}
