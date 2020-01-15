using MatchService.Data.Entity.MatchAggregate;
using MatchService.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchService.EF.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        public void CreateMatch(Match match)
        {
            using(var context = new MatchContext())
            {
                context.Matches.Add(match);
                context.SaveChanges();
            }
        }

        public Match Get(int matchId)
        {
            using (var context = new MatchContext())
            {
                return context.Matches
                    .Include("PlaceAtMatches")
                    .FirstOrDefault(m => m.Id == matchId);
            }
        }

        public List<Match> GetAllMatches()
        {
            using (var context = new MatchContext())
            {
                return context.Matches.ToList();
            }
        }

        public List<Match> GetMatches(DateTime date, int? stadiumId = null)
        {
            using (var context = new MatchContext())
            {
                var matches = context.Matches.ToList();
                return matches.Where(m => m.DateTime.Date == date && (stadiumId == null || m.StadiumId == stadiumId)).ToList();
            }
        }

        public PlaceAtMatch GetPlaceAtMatch(int id)
        {
            using (var context = new MatchContext())
            {
                return context.PlaceAtMatches
                    .Include("Match")
                    .FirstOrDefault(p => p.Id == id);
            }
        }
    }
}
