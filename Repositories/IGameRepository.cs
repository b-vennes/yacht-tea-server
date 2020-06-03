namespace YachtTea.Repositories
{
    using System.Threading.Tasks;
    using YachtTea.Repositories.Models;

    public interface IGameRepository
    {
        Task UpdateGameState(Game nextGameState);

        Task<Game> GetGameState(string userId);
    }
}