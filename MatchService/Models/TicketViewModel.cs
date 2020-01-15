using MatchService.Data.Entity.MatchAggregate;
using MatchService.Data.Entity.StadiumAggregate;
using MatchService.Data.Entity.TicketAggregate;
using System;

namespace MatchService.Models
{
    public class TicketViewModel
    {
        public Ticket Ticket { get; set; }
        public DateTime DateTime { get; set; }
        public Stadium Stadium { get; set; }
        public PlaceAtMatch PlaceAtMatch { get; set; }
    }
}