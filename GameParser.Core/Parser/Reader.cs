using System.IO;
using System.Threading.Tasks;

namespace GameParser.Core
{
    public class Reader
    {
        private readonly string localPath;

        public Reader(string localPath)
        {
            this.localPath = localPath;
        }

        public async Task<string> ReadAsync()
        {
            string json = "";
            using (var stream = new StreamReader(localPath))
            {
                json = await stream.ReadToEndAsync();
            }
            return json;
        }

        public string Read()
        {
            string json = "";
            using (var stream = new StreamReader(localPath))
            {
                json = stream.ReadToEnd();
            }
            return json;
        }
    }

    
}
