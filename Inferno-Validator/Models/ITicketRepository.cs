using Inferno_Validator.Firebase.Models;

namespace Inferno_Validator.Models
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetTicketsAsync();
    }
}
