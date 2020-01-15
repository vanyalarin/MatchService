namespace MatchService.Models
{
    public class CreateTicketModel
    {
        public int ReservationId { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
    }
}