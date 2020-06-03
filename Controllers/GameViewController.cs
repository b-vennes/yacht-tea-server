namespace YachtTea.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Paramore.Darker;
    using YachtTea.Queries;
    using YachtTea.Views;

    [Route("[controller]")]
    [ApiController]
    public class GameViewController : ControllerBase
    {
        private readonly ILogger<GameViewController> _logger;

        private readonly IQueryProcessor _queryProcessor;

        public GameViewController(ILogger<GameViewController> logger, IQueryProcessor queryProcessor)
        {
            _logger = logger;
            _queryProcessor = queryProcessor;
        }

        [HttpGet("query")]
        public async Task<IActionResult> QueryGame([FromQuery] string userId)
        {
            var query = new GameQuery(userId);

            GameView gameView;

            try
            {
                gameView = await _queryProcessor.ExecuteAsync<GameView>(query);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurred in game query for user {query.UserId}: {ex.Message}.");

                return new StatusCodeResult(StatusCodes.Status500InternalServerError); 
            }

            return Ok(gameView);
        }

    }
}