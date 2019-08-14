using GameParser.Core;
using System.IO;
using System.Threading.Tasks;

namespace GameParser.Test
{
    public static class ObjectFactory
    {
        public static async Task<string> JsonExample()
        {
            string path = $"{Directory.GetCurrentDirectory()}\\games.json";

            return await new Reader(path).ReadAsync();
        }

        public static string JsonExampleFromInternet()
        {
            var uri = Api.GamesUrl;

            return new UrlReader(uri).Read();
        }

        public static Entity AlterParadox => new Entity(1, "Alter Paradox");
    }
}
