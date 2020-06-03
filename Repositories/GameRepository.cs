namespace YachtTea.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using YachtTea.Repositories.Models;

    public class GameRepository : IGameRepository
    {
        private List<Game> GameStates { get; set; } 

        public async Task UpdateGameState(Game nextGameState)
        {
            var gameStateToUpdate = GameStates.FirstOrDefault(g => g.UserId == nextGameState.UserId);

            if (gameStateToUpdate == null)
            {
                GameStates.Add(nextGameState);
            }
            else
            {
                gameStateToUpdate = nextGameState;
            }
        }

        public async Task<Game> GetGameState(string userId)
        {
            return GameStates.FirstOrDefault(g => g.UserId == userId);
        }
    }
}