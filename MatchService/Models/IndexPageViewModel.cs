using MatchService.Data.Entity.StadiumAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatchService.Models
{
    public class IndexPageViewModel
    {
        public List<Stadium> Stadiums{ get; set; }
    }
}