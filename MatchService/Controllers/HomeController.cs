using MatchService.Data.Entity.MatchAggregate;
using MatchService.Data.Repositories;
using MatchService.Domain.Interfaces;
using MatchService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatchService.Controllers
{
    public class HomeController : Controller
    {
        IStadiumRepository _stadiumRepo;
        IMatchRepository _matchRepo;
        IScheduleService _scheduleService;
        IReservationService _reservationService;
        IPriceCalculationStrategy _priceCalculationStrategy;
        ITicketService _ticketService;
        ITicketRepository _ticketRepo;
        IReservationRepository _reservationRepo;
        public HomeController(IStadiumRepository stadiumRepo, IMatchRepository matchRepo,
            IScheduleService scheduleService, IReservationService reservationService,
            IPriceCalculationStrategy priceCalculationStrategy, ITicketService ticketService,
            ITicketRepository ticketRepo, IReservationRepository reservationRepo)
        {
            _stadiumRepo = stadiumRepo;
            _matchRepo = matchRepo;
            _scheduleService = scheduleService;
            _reservationService = reservationService;
            _priceCalculationStrategy = priceCalculationStrategy;
            _ticketService = ticketService;
            _ticketRepo = ticketRepo;
            _reservationRepo = reservationRepo;
        }
        public ActionResult Index()
        {
            var model = new IndexPageViewModel()
            {
                Stadiums = _stadiumRepo.GetAllStadiums()
            };
            return View(model);
        }

        public ActionResult GetDates(int stadiumId)
        {
            var model = new GetDatesViewModel() { Dates = new List<DateTime>(), StadiumId = stadiumId};

            var startDate = DateTime.Now.Date;
            var endDate = DateTime.Now.AddDays(7).Date;
            for (var d = startDate; d < endDate; d = d.AddDays(1))
            {
                model.Dates.Add(d.Date);
            }

            return View(model);
        }

        public ActionResult GetMatches(int stadiumId, DateTime date)
        {
            var model = new GetMatchesViewModel()
            {
                Date = date,
                StadiumId = stadiumId,
                Matches = _matchRepo.GetMatches(date, stadiumId)
            };
            return View(model);
        }

        public ActionResult AddMatch(int stadiumId, DateTime date)
        {
            var model = new AddMatchViewModel()
            {
                AvailableTimes = _scheduleService.GetAvailableTimesForNewMatch(stadiumId, date),
                Date = date,
                StadiumId = stadiumId
            };
            return View(model);
        }
        public ActionResult CreateMatch(int stadiumId, DateTime dateTime)
        {
            var model = new CreateMatchViewModel()
            {
                DateTime = dateTime,
                StadiumId = stadiumId
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateMatch(int stadiumId, DateTime dateTime, string header)
        {
            _scheduleService.CreateMatch(stadiumId, dateTime, header);
            return RedirectToAction("Index");
        }

        public ActionResult PlacesAtMatch(int matchId)
        {
            var match = _matchRepo.Get(matchId);
            var stadium = _stadiumRepo.Get(match.StadiumId);
            var model = new PlacesAtMatchViewModel()
            {
                Match = match,
                Sectors = stadium.Sectors.ToDictionary(x => x.Number),
                PlacesBySector = match.PlaceAtMatches.GroupBy(x => x.SectorNumber).ToDictionary(x => x.Key, x => x.ToList()),
                ReservedPlaces = match.PlaceAtMatches.Where(p => _reservationService.PlaceIsOccupied(p)).Select(p => p.Id).ToList(),
                Stadium = stadium,
            };
            return View(model);
        }

        public ActionResult ReservePlace(int placeId)
        {
            var place = _matchRepo.GetPlaceAtMatch(placeId);

            var reservation = _reservationService.Reserve(place);
            var model = new ReservationViewModel()
            {
                Reservation = reservation,
                PlaceInRun = place,
                PriceComponents = _priceCalculationStrategy.CalculatePrice(place),
                DateTime = place.Match.DateTime,
                Stadium = _stadiumRepo.Get(place.Match.StadiumId),
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateTicket(int reservationId, string firstName, string lastName)
        {
            var tick = _ticketService.CreateTicket(reservationId, firstName, lastName);
            return RedirectToAction("Ticket", new { id = tick.Id });
        }

        public ActionResult Ticket(int id)
        {
            var ticket = _ticketRepo.Get(id);
            var reservation = _reservationRepo.Get(ticket.Id);
            var placeAtMatch = _matchRepo.GetPlaceAtMatch(reservation.PlaceAtMatchId);

            var ticketWM = new TicketViewModel();
            ticketWM.Ticket = ticket;
            ticketWM.PlaceAtMatch = placeAtMatch;
            ticketWM.DateTime = placeAtMatch.Match.DateTime;
            ticketWM.Stadium = _stadiumRepo.Get(placeAtMatch.Match.StadiumId);

            return View(ticketWM);
        }
    }
}