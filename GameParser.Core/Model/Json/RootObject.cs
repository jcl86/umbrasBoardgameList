using System.Collections.Generic;
using System.Linq;

namespace GameParser.Core
{
    public class RootObject : IConvert<IEnumerable<BoardGame>>
    {
        public bool EsCorrecto { get; set; }
        public List<ListaJuego> ListaJuegos { get; set; }
        public string MensajeError { get; set; }

        public IEnumerable<BoardGame> Convert() => ListaJuegos.Select(x => x.Convert()).ToList();
        
    }
}
