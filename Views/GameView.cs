namespace YachtTea.Views
{

    /// <summary>
    /// The view for the current status of a game.
    /// </summary>
    public class GameView
    {
        public GameView()
        {
            Scorecard = new ScorecardView();
        }

        public int UserId { get; set; }

        public int GameId { get; set; }

        public int TurnNumber { get; set; }

        public ScorecardView Scorecard { get; set; }
    }
}