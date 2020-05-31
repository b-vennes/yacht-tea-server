namespace YachtTea.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Paramore.Darker;
    using YachtTea.Controllers.Messages;
    using YachtTea.Queries;
    using YachtTea.Views;

    [Route("[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;

        private readonly IQueryProcessor _queryProcessor;

        public GameController(ILogger<GameController> logger, IQueryProcessor queryProcessor)
        {
            _logger = logger;
            _queryProcessor = queryProcessor;
        }

        [HttpPost("query")]
        public async Task<IActionResult> QueryGame([FromBody] GameQueryMessage queryMessage)
        {
            var query = new GameQuery(queryMessage.UserId);

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