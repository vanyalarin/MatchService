using MatchService.Data.Entity.MatchAggregate;
using MatchService.Data.Entity.TicketAggregate;
using MatchService.Data.Repositories;
using MatchService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchService.Domain.Services
{
    public class DefaultPriceCalculationStrategy : IPriceCalculationStrategy
    {
        private IMatchRepository _matchRepository;
        private IStadiumRepository _stadiumRepository;

        public DefaultPriceCalculationStrategy(IMatchRepository matchRepository, IStadiumRepository stadiumRepository) {
            _matchRepository = matchRepository;
            _stadiumRepository = stadiumRepository;
        }

        public List<PriceComponent> CalculatePrice(PlaceAtMatch placeInRun)
        {
            var components = new List<PriceComponent>();

            var match = _matchRepository.Get(placeInRun.Match.Id);
            var stadium = _stadiumRepository.Get(match.StadiumId);
            var place = 
                stadium.Sectors
                    .Select(s => s.Places.SingleOrDefault(pl => 
                        pl.Number == placeInRun.Number && 
                        s.Number == placeInRun.SectorNumber))
                    .SingleOrDefault(x => x != null);

            var placeComponent = new PriceComponent() { Name = "Main price" };
            placeComponent.Value = place.Sector.DefaultPrice * place.PriceMultiplier;
            components.Add(placeComponent);


            if (placeComponent.Value > 30) {
                var cashDeskComponent = new PriceComponent()
                {
                    Name = "Cash desk service tax",
                    Value = placeComponent.Value * 0.2m
                };
                components.Add(cashDeskComponent);
            }

            return components;
        }
    }
}
