using MatchService.Data.Entity.MatchAggregate;
using MatchService.Data.Entity.StadiumAggregate;
using System;
using System.Collections.Generic;

namespace MatchService.Models
{
   public class PlacesAtMatchViewModel
    {
        public Match Match { get; set; }
        public Dictionary<int, Sector> Sectors { get; set; }
        public Dictionary<int, List<PlaceAtMatch>> PlacesBySector { get; set; }
        public List<int> ReservedPlaces { get; set; }
        public Stadium Stadium { get; set; }
    }
}