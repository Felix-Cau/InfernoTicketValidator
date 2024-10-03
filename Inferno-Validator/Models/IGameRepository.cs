using Inferno_Validator.Firebase.Models;

namespace Inferno_Validator.Models
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetGamesAsync();
    }
}
