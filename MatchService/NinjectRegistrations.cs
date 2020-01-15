using MatchService.Data.Repositories;
using MatchService.Domain.Interfaces;
using MatchService.Domain.Services;
using MatchService.EF.Repositories;
using Ninject.Modules;
using TicketsDemo.Domain.DefaultImplementations;

namespace MatchService
{
    internal class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IMatchRepository>().To<MatchRepository>();
            Bind<IReservationRepository>().To<ReservationRepository>();
            Bind<IStadiumRepository>().To<StadiumRepository>();
            Bind<ITicketRepository>().To<TicketRepository>();

            Bind<IPriceCalculationStrategy>().To<DefaultPriceCalculationStrategy>();
            Bind<IReservationService>().To<ReservationService>();
            Bind<IScheduleService>().To<ScheduleService>();
            Bind<ITicketService>().To<TicketService>();
        }
    }
}