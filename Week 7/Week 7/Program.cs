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

                //task 2

                if (taskNumber == "2")
                {
                    Console.WriteLine("This is task 2");
                    Console.WriteLine("Please enter array size");
                    var arraySizeInput = Console.ReadLine();
                    int arraySize;
                    bool arraySizeCheck = int.TryParse(arraySizeInput, out arraySize);
                    if (arraySizeCheck is true) {
                        var jackpotArray = new string[arraySize];
                        for (int i = 0; i < jackpotArray.Length; i++)
                        {
                            Console.WriteLine($"Please enter element #{i+1}");
                            jackpotArray[i] = Console.ReadLine();
                        }
                        bool jackpotCheck = jackpotArray.GroupBy(x => x).Count()==1;
                        if (jackpotCheck is true) Console.WriteLine("YES");
                        else Console.WriteLine("NO");
                    }
                    else { Console.WriteLine("Please enter a whole number"); }

                }







            }
        }
    }
}
