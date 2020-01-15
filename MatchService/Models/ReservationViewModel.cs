using MatchService.Data.Entity.MatchAggregate;
using MatchService.Data.Entity.ReservationAggregate;
using MatchService.Data.Entity.StadiumAggregate;
using MatchService.Data.Entity.TicketAggregate;
using System;
using System.Collections.Generic;

namespace MatchService.Models
{
    public class ReservationViewModel
    {
        public Reservation Reservation { get; set; }
        public PlaceAtMatch PlaceInRun { get; set; }
        public List<PriceComponent> PriceComponents { get; set; }
        public DateTime DateTime { get; set; }
        public Stadium Stadium { get; set; }
    }
}