using MatchService.Data.Entity.StadiumAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchService.Data.Repositories
{
    public interface IStadiumRepository
    {
        List<Stadium> GetAllStadiums();
        Stadium Get(int stadiumId);
        void CreateStadium(Stadium stadium);
    }
}
