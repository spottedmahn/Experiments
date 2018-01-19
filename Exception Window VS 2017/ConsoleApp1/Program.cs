using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //yes I can
            //throw new Exception("can i bring up the dialog again");

            Task.Run(async () =>
            {
                await DoStuff1Async();
            }).GetAwaiter().GetResult();
        }

        private static async Task DoStuff1Async()
        {
            await DoStuff2Async();
        }

        private static Task DoStuff2Async()
        {
            throw new NotImplementedException();
        }
    }
}
