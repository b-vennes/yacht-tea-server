namespace YachtTea.Repositories.Models
{
    using System.Collections.Generic;

    public class Game
    {
        public string UserId { get; set; }

        public Scorecard Scorecard { get; set; }

        public int TurnNumber { get; set; }

        public List<int> PreviousRoll { get; set; }
    }
}