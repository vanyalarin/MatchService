using MatchService.Data.Entity.TicketAggregate;
using MatchService.Data.Repositories;
using MatchService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsDemo.Domain.DefaultImplementations
{
    public class TicketService : ITicketService
    {
        private ITicketRepository _tickRepo;
        private IReservationRepository _resRepo;
        private IMatchRepository _matchRepo;
        private IPriceCalculationStrategy _priceCalculationStrategy;

        public TicketService(ITicketRepository tickRepo, IReservationRepository resRepo,
            IMatchRepository matchRepo, IPriceCalculationStrategy priceCalculationStrategy)
        {
            _tickRepo = tickRepo;
            _resRepo = resRepo;
            _matchRepo = matchRepo;
            _priceCalculationStrategy = priceCalculationStrategy;
        }

        public Ticket CreateTicket(int reservationId, string fName, string lName)
        {
            var res = _resRepo.Get(reservationId);

            if (res.TicketId != null) {
                throw new InvalidOperationException("ticket has been already issued to this reservation, unable to create another one");
            }

            var placeInRun = _matchRepo.GetPlaceAtMatch(res.PlaceAtMatchId);

            var newTicket = new Ticket()
            {
                ReservationId = res.Id,
                FirstName = fName,
                LastName = lName,
                PriceComponents = new List<PriceComponent>()
            };
            
            newTicket.PriceComponents = _priceCalculationStrategy.CalculatePrice(placeInRun);

            _tickRepo.CreateTicket(newTicket);
            return newTicket;
        }
    }
}
