using System;
using System.Net.Http;

namespace APIDemo.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Request
            Console.WriteLine("Hello PPEDV API!");
            SendRequest();
            Console.ReadLine();
            #endregion
        }

        #region SendRequest
        private static async void SendRequest()
        {
            var ppedvClient = new PPEDVClient(new HttpClient());

            var result = await ppedvClient.Client.GetStringAsync("https://localhost:44328/api/Cars");

            Console.WriteLine(result);

            Console.WriteLine("Connection done");
        }
        #endregion
    }
}
