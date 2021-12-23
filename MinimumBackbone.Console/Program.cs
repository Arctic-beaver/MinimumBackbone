using System;

namespace MinimumBackboneConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome. Here you can use the Kraskal's algorithm.");
            ConsoleUI ui = new ConsoleUI();
            ui.EntryPoint();


            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
