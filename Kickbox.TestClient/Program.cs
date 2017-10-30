using System;
using System.Threading.Tasks;

namespace Kickbox.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                try
                {
                    var kickBoxApi = new KickBoxApi("KEY");
                    var valid = await kickBoxApi.VerifyAsync("your_email@gmail.com");

                    Console.WriteLine($"Valid: {valid}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }).GetAwaiter().GetResult();

            Task.Run(async () =>
            {
                try
                {
                    var kickBoxApi = new KickBoxApi("KEY");
                    var response = await kickBoxApi.VerifyWithResponse("your_email@gmail.com");

                    Console.WriteLine($"Response: {response}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }).GetAwaiter().GetResult();

            Console.WriteLine("Done...");
            Console.ReadKey();
        }
    }
}
