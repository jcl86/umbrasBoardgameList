using System;
using System.Net;

namespace GameParser.Core
{
    public class UrlReader
    {
        private readonly Uri url;

        public UrlReader(Uri url)
        {
            this.url = url;
        }

        public string Read()
        {
            string json = "";
            using (var webClient = new WebClient())
            {
                json = webClient.DownloadString(url);
            }
            
            return json;
        }
    }

    
}
