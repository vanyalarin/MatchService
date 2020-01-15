using MatchService.Data.Entity.MatchAggregate;
using MatchService.Data.Entity.ReservationAggregate;
using MatchService.Data.Entity.StadiumAggregate;
using MatchService.Data.Entity.TicketAggregate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchService.EF
{
    public class MatchContext : DbContext
    {
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<PlaceAtMatch> PlaceAtMatches { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Stadium>().HasMany(s => s.Sectors).WithRequired(s => s.Stadium);

            modelBuilder.Entity<Sector>().HasMany(s => s.Places).WithRequired(p => p.Sector);

            modelBuilder.Entity<PlaceAtMatch>().HasRequired(p => p.Match).WithMany(m => m.PlaceAtMatches);

            modelBuilder.Entity<Ticket>().HasMany(t => t.PriceComponents).WithRequired(p => p.Ticket);

            modelBuilder.Entity<Reservation>();
        }
    }
}
