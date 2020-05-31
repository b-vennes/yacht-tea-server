namespace YachtTea.Views
{
    /// <summary>
    /// The view for a player's score card.
    /// </summary>
    public class ScorecardView
    {   
        public int Ones { get; set; }

        public int Twos { get; set; }

        public int Threes { get; set; }

        public int Fours { get; set; }

        public int Fives { get; set; }

        public int Sixes { get; set; }

        public int ThreeOfAKind { get; set; }

        public int FourOfAKind { get; set; }

        public int FullHouse { get; set; }

        public int SmallStraight { get; set; }

        public int LargeStraight { get; set; }

        public int YachtTea { get; set; }

        public int Chance { get; set; }

        public int YachtTeaBonusCount { get; set; }

        public int YachtTeaBonusTotal { get; set; }

        public int UpperBonus { get; set; }

        public int UpperTotal { get; set; }

        public int LowerTotal { get; set; }
    }
}