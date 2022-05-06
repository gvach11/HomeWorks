using System;
using System.Linq;

namespace Week_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //task chooser

                Console.WriteLine("Please select a task from 1 to 3, or type 0 to exit");
                var taskNumber = Console.ReadLine();

                //task 1

                if (taskNumber == "1")
                {
                    Console.WriteLine("This is task 1");
                    Console.WriteLine("Please enter the radius of the circle");
                    var rinput = Console.ReadLine();
                    decimal r;
                    bool rcheck = decimal.TryParse(rinput, out r);
                    if (rcheck is true) {

                        decimal smallArea = r * r / 2;
                        decimal largeArea = r * r;
                        Console.WriteLine(largeArea - smallArea);

                    }
                    else { Console.WriteLine("Please input a whole number");}
                    
                }







            }
        }
    }
}
