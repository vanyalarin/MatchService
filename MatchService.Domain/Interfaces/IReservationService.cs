using MatchService.Data.Entity.MatchAggregate;
using MatchService.Data.Entity.ReservationAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchService.Domain.Interfaces
{
    public interface IReservationService
    {
        Reservation Reserve(PlaceAtMatch place);
        bool PlaceIsOccupied(PlaceAtMatch place);
        bool IsActive(Reservation reservation);
    }
}
