using GameParser.Core;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GameParser.Test
{
    public class ParsingTests
    {
        [Fact]
        public async Task Should_read_json_file()
        {
            string json = await ObjectFactory.JsonExample();

            Assert.NotNull(json);
        }

        //[Fact(Skip = "Para no descargar el json")]
        //public async Task Should_read_json_from_Internet()
        //{
        //    string json = ObjectFactory.JsonExampleFromInternet();

        //    Assert.NotNull(json);
        //}

        [Fact]
        public async Task Should_slice_and_convert_json_info()
        {
            string json = await ObjectFactory.JsonExample();

            var result = JsonConvert.DeserializeObject<RootObject>(json);

            var games = result.Convert();

            Assert.NotNull(games);
            Assert.True(games.Count() > 0);
        }

        [Fact]
        public async Task Should_verify_first_items_info()
        {
            string json = await ObjectFactory.JsonExample();

            var result = JsonConvert.DeserializeObject<RootObject>(json);

            var games = result.Convert();
            var siPadrinoOscuro = games.ElementAt(1);

            Assert.Equal("¡Si, Padrino Oscuro!", siPadrinoOscuro.ToString());
            Assert.Equal("Jugadores recomendados: 8-11", siPadrinoOscuro.Comments);
            Assert.Equal(Dificulty.Facil, siPadrinoOscuro.Dificulty);
            Assert.Equal(25, siPadrinoOscuro.Duration);
            Assert.Equal(ObjectFactory.AlterParadox, siPadrinoOscuro.Entity);
            Assert.Equal(Family.Cartas, siPadrinoOscuro.Family);
            Assert.False(siPadrinoOscuro.InUse);
            Assert.False(siPadrinoOscuro.IsExpansion);
            Assert.Equal(11, siPadrinoOscuro.PlayerMax);
            Assert.Equal(5, siPadrinoOscuro.PlayerMin);
            Assert.Equal("", siPadrinoOscuro.Publisher);
            Assert.Equal(GameType.Party, siPadrinoOscuro.Type);
            Assert.Equal(8, siPadrinoOscuro.Years);
        }

        [Fact]
        public async Task Should_verify_no_dificulty()
        {
            string json = await ObjectFactory.JsonExample();

            var result = JsonConvert.DeserializeObject<RootObject>(json);

            var games = result.Convert();
            var arribayabajo = games.First(x => x.Id == 377);

            Assert.Equal("Arriba y Abajo", arribayabajo.ToString());
            Assert.Null(arribayabajo.Dificulty);
        }
    }
}
