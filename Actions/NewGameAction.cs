using System;
using Paramore.Brighter;
using YachtTea.Controllers.Messages;

namespace YachtTea.Actions
{
    public class NewGameAction : IRequest
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public NewGameAction(NewGameMessage newGameMessage)
        {
            Id = Guid.NewGuid();
            UserId = newGameMessage.UserId;
        }
    }
}