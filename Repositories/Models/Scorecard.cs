namespace YachtTea.Repositories.Models
{
    public class Scorecard
    {
        public int? Ones { get; set; }

        public int? Twos { get; set; }

        public int? Threes { get; set; }

        public int? Fours { get; set; }

        public int? Fives { get; set; }

        public int? Sixes { get; set; }

        public int? ThreeOfAKind { get; set; }

        public int? FourOfAKind { get; set; }

        public int? FullHouse { get; set; }

        public int? SmallStraight { get; set; }

        public int? LargeStraight { get; set; }

        public int? YachtTea { get; set; }

        public int? Chance { get; set; }

        public int YachtTeaBonusCount { get; set; }
    }
}