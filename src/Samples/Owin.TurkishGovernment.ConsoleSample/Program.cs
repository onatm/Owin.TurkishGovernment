using System;
using Microsoft.Owin.Hosting;

namespace Owin.TurkishGovernment.ConsoleSample
{
    class Program
    {
        static void Main()
        {
            const string uri = "http://localhost:1954/";

            using (WebApp.Start<Startup>(uri))
            {
                Console.WriteLine("Started");
                Console.ReadKey();
                Console.WriteLine("Stopping");
            }
        }
    }
}
