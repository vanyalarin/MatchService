using MatchService.Data.Entity.MatchAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchService.Data.Repositories
{
    public interface IMatchRepository
    {
        List<Match> GetAllMatches();
        Match Get(int matchId);
        void CreateMatch(Match match);
        List<Match> GetMatches(DateTime date, int? stadiumId = null);
        PlaceAtMatch GetPlaceAtMatch(int id);
    }
}
