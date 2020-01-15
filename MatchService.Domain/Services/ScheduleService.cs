using MatchService.Data.Entity.MatchAggregate;
using MatchService.Data.Repositories;
using MatchService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchService.Domain.Services
{
    public class ScheduleService : IScheduleService
    {
        public IMatchRepository _matchRepo;
        public IStadiumRepository _stadiumRepo;
        public IReservationRepository _reservationRepository;
        public IReservationService _resService;

        public ScheduleService(
            IMatchRepository matchRepo, 
            IStadiumRepository stadiumRepo, 
            IReservationRepository reservationRepository, 
            IReservationService resService)
        {
            _matchRepo = matchRepo;
            _stadiumRepo = stadiumRepo;
            _reservationRepository = reservationRepository;
            _resService = resService;
        }

        public Dictionary<DateTime, bool> GetAvailableTimesForNewMatch(int stadiumId, DateTime date) {
            var allMatches = _matchRepo.GetMatches(date, stadiumId);

            var retIt = new Dictionary<DateTime, bool>();
            var startTime = date.Date.AddHours(10);
            var endTime = startTime.AddHours(10);
            for (var tt = startTime; tt < endTime; tt = tt.AddHours(2)) {
                if (allMatches.Any(r => r.DateTime == tt)) {
                    retIt.Add(tt, false);
                }
                else
                {
                    retIt.Add(tt, true);
                }
            }

            return retIt;
        }


        public Match CreateMatch(int stadiumId, DateTime dateTime, string header) {
            if (GetAvailableTimesForNewMatch(stadiumId, dateTime).Count < 1)
            {
                throw new InvalidOperationException(String.Format("Train {0} is occupied at {1}. Run can not be created",stadiumId, dateTime));
            }

            var stadium = _stadiumRepo.Get(stadiumId);

            var match = new Match() { StadiumId = stadium.Id, DateTime = dateTime, Header = header, PlaceAtMatches = new List<PlaceAtMatch>() };
            

            foreach (var sector in stadium.Sectors) {
                foreach (var place in sector.Places) {
                    var newPlaceAtMatch = new PlaceAtMatch()
                    {
                        Number = place.Number,
                        SectorNumber = sector.Number,
                        Match = match
                    };
                    match.PlaceAtMatches.Add(newPlaceAtMatch);
                };
            };

            _matchRepo.CreateMatch(match);

            return match;
        }
    }
}
