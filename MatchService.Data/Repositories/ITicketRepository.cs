using MatchService.Data.Entity.TicketAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchService.Data.Repositories
{
    public interface ITicketRepository
    {
        List<Ticket> GetAllTickets();
        Ticket Get(int ticketId);
        void CreateTicket(Ticket ticket);
    }
}
