using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchService.Data.Entity.TicketAggregate
{
    public class Ticket
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ReservationId { get; set; }
        public List<PriceComponent> PriceComponents { get; set; }
    }
}
