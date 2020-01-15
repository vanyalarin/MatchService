using MatchService.Data.Entity.ReservationAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchService.Data.Repositories
{
    public interface IReservationRepository
    {
        List<Reservation> GetAllReservations();
        Reservation Get(int reservationId);
        void Update(Reservation reservation);
        void CreateReservation(Reservation reservation);
    }
}
