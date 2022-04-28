using System;

namespace Week_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) { 
            //Task Chooser

            Console.WriteLine("Please select a task from 1 to 4, or type 0 to exit");
            var taskNumber = Console.ReadLine();


            //Task 1

            if (taskNumber == "1") 
            {
                Console.WriteLine("This is task 1");
                Console.WriteLine("Please enter a number");
                var userInput1= Console.ReadLine();
                var task1Value = Convert.ToInt32(userInput1);
                var task1Result = task1Value % 5;
                Console.WriteLine(task1Result == 0 ? "YES" : "NO");
            }

            //Task 2

            else if (taskNumber == "2")
            {
                Console.WriteLine("this task 2");
                Console.WriteLine("Please enter the first number");
                var userInput1 = Console.ReadLine();
                decimal value1 = Convert.ToDecimal(userInput1);
                Console.WriteLine("Please enter the second number");
                var userInput2 = Console.ReadLine();
                decimal value2 = Convert.ToDecimal(userInput2);

                var additionResult = value1 + value2;
                Console.WriteLine($"{value1} + {value2} = {additionResult}");

                var subtractionResult = value1 > value2 ? value1 - value2:
                    value2 - value1;
                Console.WriteLine((value1 > value2) ?$"{value1} - {value2} = {subtractionResult}" : 
                    $"{value2} - {value1} = {subtractionResult}");

                var multiplicationResult = value1 * value2;
                Console.WriteLine($"{value1} * {value2} = {multiplicationResult}");

                if (multiplicationResult == 0)
                {
                    Console.WriteLine("Not Allowed to Divide by Zero");
                }
                else
                {
                    var divisionResult = value1 > value2 ? value1 / value2 :
                        value2 / value1;
                    Console.WriteLine((value1 > value2) ? $"{value1} / {value2} = {divisionResult}" :
                        $"{value2} / {value1} = {divisionResult}");
                }
                    
            }

            //Task 3
            else if (taskNumber == "3")
            {
                Console.WriteLine("this task 3");
                Console.WriteLine("Please enter X");
                var userInput1 = Console.ReadLine();
                decimal value1 = Convert.ToDecimal(userInput1);
                Console.WriteLine("Please enter Y");
                var userInput2 = Console.ReadLine();
                decimal value2 = Convert.ToDecimal(userInput2);
                Console.WriteLine($"Input: X = {userInput1}; Y = {userInput2}");
                Console.WriteLine($"Output: X = {value2}; Y = {value1}");
            }

            //task 4
            else if (taskNumber == "4")
            {
                Console.WriteLine("this task 4");
                Console.WriteLine("Please enter a number");
                var userInput1 = Console.ReadLine();
                decimal value1 = Convert.ToDecimal(userInput1);
                int multiplier = 0;
                foreach (var i in "1234567890") 
                {
                    multiplier += 1;
                    Console.WriteLine($"{value1} * {multiplier} = {value1 * multiplier}");
                }
            }

             else if (taskNumber == "0")
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Invalid Input - Please make sure to enter 1, 2, 3, 4 or 0");
                }










        }
    }
}
}