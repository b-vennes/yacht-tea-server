namespace YachtTea.Actions.Handlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Paramore.Brighter;
    using YachtTea.Repositories;

    public class NewGameActionHandlerAsync : RequestHandlerAsync<NewGameAction>
    {
        private readonly ILogger<NewGameActionHandlerAsync> _logger;

        public NewGameActionHandlerAsync(ILogger<NewGameActionHandlerAsync> logger, IGameRepository gameRepository)
        {
            _logger = logger;
        }

        public async override Task<NewGameAction> HandleAsync(NewGameAction newGameAction, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Processing new game action for user {newGameAction.UserId}");

            return newGameAction;
        }
    }
}