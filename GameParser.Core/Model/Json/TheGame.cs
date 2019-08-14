namespace GameParser.Core
{
    public class TheGame : IConvert<BoardGame>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Editorial { get; set; }
        public int Family { get; set; }
        public int Type { get; set; }
        public int Years { get; set; }
        public int PlayerMin { get; set; }
        public int PlayerMax { get; set; }
        public int Difficulty { get; set; }
        public int Duration { get; set; }
        public int IsExpansion { get; set; }
        public string Comments { get; set; }

        public BoardGame Convert()
        {
            var family = (Family)Family;
            var type = (GameType)Type;
            var dificulty = Difficulty == 0 ? (Dificulty?)null : (Dificulty)Difficulty;

            return new BoardGame(Id, Name, Editorial, family, type, Years, PlayerMin, PlayerMax, dificulty, Duration, IsExpansion != 0, Comments);
        }
    }
}
