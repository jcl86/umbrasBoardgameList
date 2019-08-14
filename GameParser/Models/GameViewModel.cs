using System.Collections.Generic;
using System.Linq;
using GameParser.Core;

namespace GameParser.Models
{
    public class GameViewModel
    {
        public IEnumerable<BoardGame> Boardgames { get; set; }
        public int? PlayerNumber { get; set; }
        public Dificulty? Level { get; set; }
        public int? Minutos { get; set; }
        public int? Edad { get; set; }
    }
}