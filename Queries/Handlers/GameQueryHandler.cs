namespace YachtTea.Queries.Handlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Paramore.Darker;
    using YachtTea.Views;

    public class GameQueryHandler : QueryHandlerAsync<GameQuery, GameView>
    {
        private readonly ILogger<GameQueryHandler> _logger;

        public GameQueryHandler(ILogger<GameQueryHandler> logger)
        {
            _logger = logger;
        }

        public override Task<GameView> ExecuteAsync(GameQuery query, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Handling game query with game id {query.GameId}.");

            var testScorecardView = new ScorecardView
            {
                Ones = 4,
                Twos = 8,
                Threes = 12,
                Fours = 16,
                Fives = 10,
                Sixes = 24
            };

            var upperTotalWithoutBonus = testScorecardView.Ones +
                testScorecardView.Twos +
                testScorecardView.Threes +
                testScorecardView.Fours +
                testScorecardView.Fives + 
                testScorecardView.Sixes;

            if (upperTotalWithoutBonus >= 35)
            {
                testScorecardView.UpperBonus = 35;
                testScorecardView.UpperTotal = upperTotalWithoutBonus + testScorecardView.UpperBonus;
            }

            var testGameView = new GameView
            {
                GameId = 1,
                UserId = 1,
                Scorecard = testScorecardView
            };

            return Task.FromResult(testGameView);
        }
    }
}