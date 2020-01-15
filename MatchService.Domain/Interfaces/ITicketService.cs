using MatchService.Data.Entity.TicketAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchService.Domain.Interfaces
{
    public interface ITicketService
    {
        Ticket CreateTicket(int reservationId,string firstName, string lastName);
    }
}
