using System.Collections;
using System.Collections.Generic;

namespace GameParser.Core
{
    public class ListaJuego : IConvert<BoardGame>
    {
        public int Id { get; set; }
        public TheGame TheGame { get; set; }
        public Association Association { get; set; }
        public object Comments { get; set; }
        public int Status { get; set; }

        public BoardGame Convert()
        {
            var game = TheGame.Convert();
            game.SetEntity(Association.Convert());
            if (Status != 0)
                game.SetUsed();
            return game;
        }
    }
}
