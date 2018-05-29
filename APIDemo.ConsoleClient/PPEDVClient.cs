using System.Net.Http;

namespace APIDemo.ConsoleClient
{
    public class PPEDVClient
    {
        public PPEDVClient(HttpClient client)
        {
            Client = client;
        }

        public HttpClient Client { get; }
    }
}
