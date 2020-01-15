using MatchService.Data.Entity.ReservationAggregate;
using MatchService.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchService.EF.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        public void CreateReservation(Reservation reservation)
        {
            using (var context = new MatchContext())
            {
                context.Reservations.Add(reservation);
                context.SaveChanges();
            }
        }

        public Reservation Get(int reservationId)
        {
            using (var context = new MatchContext())
            {
                return context.Reservations.FirstOrDefault(r => r.Id == reservationId);
            }
        }

        public List<Reservation> GetAllReservations()
        {
            using (var context = new MatchContext())
            {
                return context.Reservations.ToList();
            }
        }

        public void Update(Reservation reservation)
        {
            using (var context = new MatchContext())
            {
                context.Entry(reservation).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
