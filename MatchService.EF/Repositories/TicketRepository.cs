using MatchService.Data.Entity.TicketAggregate;
using MatchService.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchService.EF.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        public void CreateTicket(Ticket ticket)
        {
            using (var context = new MatchContext())
            {
                context.Tickets.Add(ticket);
                context.SaveChanges();
            }
        }

        public Ticket Get(int ticketId)
        {
            using (var context = new MatchContext())
            {
                return context.Tickets
                    .Include("PriceComponents")
                    .FirstOrDefault(t => t.Id == ticketId);
            }
        }

        public List<Ticket> GetAllTickets()
        {
            using (var context = new MatchContext())
            {
                return context.Tickets.ToList();
            }
        }
    }
}
