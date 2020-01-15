using System;
using System.Collections.Generic;

namespace MatchService.Models
{
    public class AddMatchViewModel
    {
        public Dictionary<DateTime, bool> AvailableTimes { get; set; }
        public DateTime Date { get; set; }
        public int StadiumId { get; set; }
    }
}