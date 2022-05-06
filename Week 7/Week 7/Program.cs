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

                Console.WriteLine("Please select a task from 1 to 6, or type 0 to exit");
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
                        Console.WriteLine($"Difference between the areas is {largeArea - smallArea}");

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

                //task 3

                if (taskNumber == "3")
                {
                    Console.WriteLine("This is task 3");
                    var teamResults = new int[3];
                    int count = 0;
                    int totalScore = 0;
                    for (int i = 0; i < teamResults.Length; i++)
                    {
                        count+=1;
                        if (count == 1)
                        {
                            Console.WriteLine("Please enter the number of wins");
                            var winInput = Console.ReadLine();
                            bool winInputCheck = int.TryParse(winInput, out teamResults[i]);
                            if (winInputCheck is false) { Console.WriteLine("Please enter a whole number");
                                break;
                            }
                            totalScore += teamResults[i] * 3;
                        }
                        if (count == 2)
                        {
                            Console.WriteLine("Please enter the number of draws");
                            var drawInput = Console.ReadLine();
                            bool drawInputCheck = int.TryParse(drawInput, out teamResults[i]);
                            if (drawInputCheck is false) { Console.WriteLine("Please enter a whole number");
                                break;
                            }
                            totalScore += teamResults[i] * 1;
                        }
                        if (count == 3)
                        {
                            Console.WriteLine("Please enter the number of losses");
                            var lossInput = Console.ReadLine();
                            bool lossInputCheck = int.TryParse(lossInput, out teamResults[i]);
                            if (lossInputCheck is false) { Console.WriteLine("Please enter a whole number");
                                break;
                            }
                            Console.WriteLine($"Teams total points are {totalScore}");
                        }
                    }
                    
                }

                //task 4

                if (taskNumber == "4")
                {
                    Console.WriteLine("This is task 4");
                    var weekArray = new int[7];
                    int totalPay = 0;
                    bool dayInputCheck = true;
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine($"Please enter hours worked on day {i+1}");
                        var dayInput = Console.ReadLine();
                        dayInputCheck = int.TryParse(dayInput, out weekArray[i]);
                        if (dayInputCheck is false)
                        {
                            Console.WriteLine("Please enter a whole number");
                            break;
                        }
                        if (weekArray[i] <= 8) { totalPay += weekArray[i] * 10; }
                        if (weekArray[i] > 8) { totalPay += 80 + ((weekArray[i] - 8) * 15); }
                    }
                    if (dayInputCheck is true) { 
                        for (int i = 5; i < 7; i++)
                        {
                            Console.WriteLine($"Please enter hours worked on day {i + 1}");
                            var dayInput = Console.ReadLine();
                            dayInputCheck = int.TryParse(dayInput, out weekArray[i]);
                            if (dayInputCheck is false)
                            {
                                Console.WriteLine("Please enter a whole number");
                                break;
                            }
                            if (weekArray[i] <= 8) { totalPay += weekArray[i] * 20; }
                            if (weekArray[i] > 8) { totalPay += 160 + ((weekArray[i] - 8) * 30); }
                            
                        }

                        

                    }
                    if (dayInputCheck is true) { Console.WriteLine($"Total Pay is {totalPay}"); }
                }

                //task 5

                if (taskNumber == "5")
                {
                    Console.WriteLine("This is task 5");
                    Console.WriteLine("Please enter the number of days");
                    var arraySizeInput = Console.ReadLine();
                    int arraySize;
                    bool arraySizeCheck = int.TryParse(arraySizeInput, out arraySize);
                    int progressDays = 0;
                    if (arraySizeCheck is true)
                    {
                        bool distanceCheck = true;
                        var daysArray= new int[arraySize];
                        for (int i = 0; i < daysArray.Length; i++)
                        {
                            Console.WriteLine($"Enter distance for day {i+1}");
                            var distanceInput = Console.ReadLine();
                            distanceCheck = int.TryParse(distanceInput, out daysArray[i]);
                            if (distanceCheck is false)
                            {
                                Console.WriteLine("Please enter a whole number");
                                break;
                            }
                        }
                        for (int i = 1 ; i < daysArray.Length; i++) {
                            if (daysArray[i] > daysArray[i - 1]) { progressDays++; }

                        }
                        if (distanceCheck is true)
                            Console.WriteLine($"Total progress days: {progressDays}");
                    }
                    else { Console.WriteLine("Please enter a whole number"); }
                    }

                //task 6

                if (taskNumber == "6")
                {
                    Console.WriteLine("This is task 6");
                    Console.WriteLine("Please enter array size");
                    var arraySizeInput = Console.ReadLine();
                    int arraySize;
                    bool arraySizeCheck = int.TryParse(arraySizeInput, out arraySize);
                    if (arraySizeCheck is true)
                    {
                        var task6Array = new string[arraySize];
                        for (int i = 0; i < task6Array.Length; i++)
                        {
                            Console.WriteLine($"Please enter element #{i + 1}");
                            task6Array[i] = Console.ReadLine();
                        }
                        Console.WriteLine("Please enter the number of letters");
                        int numOfLetters;
                        bool numOfLettersCheck = int.TryParse(Console.ReadLine(), out numOfLetters);
                        if (numOfLettersCheck is true)
                        {
                            var output = from x in task6Array
                                              where x.Length == numOfLetters
                                              select x;
                            Console.Write($"Words consisting of {numOfLetters} letters are: ");
                            foreach (var x in output) { Console.Write($"{x} "); }
                            Console.WriteLine("");
                                              
                        }
                        else { Console.WriteLine("Please input a whole number"); }

                    }
                    else { Console.WriteLine("Please input a whole number"); }

                }

                //exit

                if (taskNumber == "0") { break; }





            }
        }
    }
}
