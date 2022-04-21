using System;

namespace Week4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Giorgi Vachnadze");
            Console.Write("Please enter text: ");
            var userInput = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-------------------------");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Your text: " + userInput);
            Console.ResetColor();
        }
    }
}
