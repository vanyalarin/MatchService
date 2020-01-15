using System;
using System.Collections.Generic;

namespace MatchService.Models
{
    public class GetDatesViewModel
    {
        public List<DateTime> Dates { get; set; }
        public int StadiumId { get; set; }
    }
}