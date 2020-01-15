using MatchService.Data.Entity.StadiumAggregate;
using MatchService.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchService.EF.Repositories
{
    public class StadiumRepository : IStadiumRepository
    {
        public void CreateStadium(Stadium stadium)
        {
            using(var context = new MatchContext())
            {
                context.Stadiums.Add(stadium);
                context.SaveChanges();
            }
        }

        public Stadium Get(int stadiumId)
        {
            using (var context = new MatchContext())
            {
                return context.Stadiums
                    .Include("Sectors")
                    .Include("Sectors.Places")
                    .FirstOrDefault(s => s.Id == stadiumId);
            }
        }

        public List<Stadium> GetAllStadiums()
        {
            using (var context = new MatchContext())
            {
                return context.Stadiums.ToList();
            }
        }
    }
}
