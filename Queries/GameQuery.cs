namespace YachtTea.Queries
{
    using Paramore.Darker;
    using YachtTea.Views;

    public class GameQuery : IQuery<GameView>
    {
        public int GameId { get; }

        public GameQuery(int gameId)
        {
            GameId = gameId;
        }
    }
}