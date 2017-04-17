using System;
using System.ServiceModel;

namespace SampleWCFStandaloneService
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(DataSourceService)))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Starting up service endpoint");

                host.Open();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Service started");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();

                host.Close();
            }
        }
    }
}
