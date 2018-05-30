using System.Net.Http;

namespace APIDemo.ConsoleClient
{
    public class PPEDVClient
    {
        #region PPEDVClient
        public PPEDVClient(HttpClient client)
        {
            Client = client;
        }

        public HttpClient Client { get; }
        #endregion
    }
}
