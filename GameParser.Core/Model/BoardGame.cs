using System;

namespace GameParser.Core
{
    public class BoardGame
    {
        private readonly string name;

        public int Id { get; }
        public string Publisher { get; }
        public Family Family { get; }
        public GameType Type { get; }
        public int Years { get; }
        public int PlayerMin { get; }
        public int PlayerMax { get; }
        public Dificulty? Dificulty { get;  }
        public int Duration { get; }
        public bool IsExpansion { get; }
        public string Comments { get; }
        public bool InUse { get; private set; }
        public bool SetUsed() => InUse = true;

        public Entity Entity { get; private set; }
        public void SetEntity(Entity entity) => Entity = entity;

        public BoardGame(int id, string name, string publisher, Family family, GameType type, int years, int playerMin, int playerMax, 
            Dificulty? dificulty, int duration, bool isExpansion, string comments)
        {
            this.Id = id;
            this.name = name;
            Publisher = publisher;
            Family = family;
            Type = type;
            Years = years;
            PlayerMin = playerMin;
            PlayerMax = playerMax;
            Dificulty = dificulty;
            Duration = duration;
            IsExpansion = isExpansion;
            Comments = comments;
            InUse = false;
        }
        public override bool Equals(object obj)
        {
            return obj is BoardGame boardgame &&
                   Id == boardgame.Id;
        }

        public override int GetHashCode() => HashCode.Combine(Id);

        public override string ToString() => name;
    }
}
