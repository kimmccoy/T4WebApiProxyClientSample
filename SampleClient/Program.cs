using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // run as a task so we can call async methods
            Task runTask = Task.Run(() => Run());
            runTask.Wait();
        }

        public async static Task Run()
        {
            try
            {


                Console.WriteLine("WebApi T4 Template Proxy Demo");

                var urlBase = "http://localhost:21263/";
                Console.WriteLine($"Using website running at {urlBase}. Check your port number is correct or change this code.");

                Console.WriteLine("Get a thing (Press enter)");
                Console.ReadKey();

                WebProxies.Configuration.MyWebApiProxyBaseAddress = urlBase;

                var client = new WebProxies.ThingClient();

                var thing = await client.GetAsync(2);

                // pretty print as json
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(thing, Newtonsoft.Json.Formatting.Indented));
                Console.WriteLine();
                Console.WriteLine("Post a thing");
                Console.ReadKey();
                var result = await client.PostAsync(thing);
                Console.WriteLine("Result. Size property has been updated...");
                Console.WriteLine();
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented));

            }
            catch (Exception exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(exception);
                throw;
            }
            Console.WriteLine();
            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
