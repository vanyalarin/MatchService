using MatchService.Data.Entity.MatchAggregate;
using MatchService.Data.Entity.ReservationAggregate;
using MatchService.Data.Repositories;
using MatchService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchService.Domain.Services
{
    public class ReservationService : IReservationService
    {
        IReservationRepository _resRepo;

        public ReservationService(IReservationRepository resRepo)
        {
            _resRepo = resRepo;
        }


        public Reservation Reserve(PlaceAtMatch place)
        {
            if (PlaceIsOccupied(place))
                throw new InvalidOperationException(String.Format("place {0} can't be reserved becouse it is currently occupied", place.Id));

            var createIt = new Reservation()
            {
                Start = DateTime.Now,
                End = DateTime.Now.AddMinutes(20),
                PlaceAtMatchId = place.Id,
            };

            _resRepo.CreateReservation(createIt);

            return createIt;
        }

        public bool IsActive(Reservation reservation) {
            return reservation.TicketId.HasValue || reservation.Start < DateTime.Now && reservation.End > DateTime.Now;
        }

        public bool PlaceIsOccupied(PlaceAtMatch place)
        {
            var reservationsForCurrentPlace = _resRepo.GetAllReservations().Where(r => r.PlaceAtMatchId == place.Id);
            if (reservationsForCurrentPlace == null)
                return false;

            var activeReservationFound = false;
            foreach(var res in reservationsForCurrentPlace)
            {
                if(IsActive(res))
                {
                    activeReservationFound = true;
                }
            }

            return activeReservationFound;
        }
    }
}
