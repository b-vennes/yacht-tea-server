namespace YachtTea.Queries
{
    using Paramore.Darker;
    using YachtTea.Views;

    public class GameQuery : IQuery<GameView>
    {
        public string UserId { get; }

        public GameQuery(string userId)
        {
            UserId = userId;
        }
    }
}