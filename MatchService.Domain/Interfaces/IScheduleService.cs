using MatchService.Data.Entity.MatchAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchService.Domain.Interfaces
{
    public interface IScheduleService
    {
        Dictionary<DateTime, bool> GetAvailableTimesForNewMatch(int stadiumId, DateTime date);
        Match CreateMatch(int stadiumId, DateTime dateTime, string header);
    }
}
