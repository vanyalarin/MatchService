using MatchService.Data.Entity.MatchAggregate;
using System;
using System.Collections.Generic;

namespace MatchService.Models
{
    public class GetMatchesViewModel
    {
        public DateTime Date { get; set; }
        public List<Match> Matches { get; set; }
        public int StadiumId { get; internal set; }
    }
}