namespace YachtTea.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Paramore.Brighter;
    using YachtTea.Actions;
    using YachtTea.Controllers.Messages;

    [Route("[controller]")]
    [ApiController]
    public class GameActionController : ControllerBase
    {
        public readonly ILogger<GameActionController> _logger;

        public readonly IAmACommandProcessor _actionProcessor;

        public GameActionController(ILogger<GameActionController> logger, IAmACommandProcessor actionProcessor)
        {
            _logger = logger;
            _actionProcessor = actionProcessor;
        }

        [HttpPost("NewGame")]
        public async Task<IActionResult> NewGame([FromBody] NewGameMessage message)
        {
            var action = new NewGameAction(message);

            try
            {
                await _actionProcessor.SendAsync(action);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while creating a new game: {ex}");
            }

            return Ok();
        }
    }
}