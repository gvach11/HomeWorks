using System;

namespace Week_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) { 
            //Task Chooser

            Console.WriteLine("Please select a task from 1 to 5, or type 0 to exit");
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
                var tempValue = "";
                Console.WriteLine($"Input: X = {userInput1}; Y = {userInput2}");

                tempValue = userInput1;
                userInput1 = userInput2;
                userInput2 = tempValue;
                Console.WriteLine($"Output: X = {userInput1}; Y = {userInput2}");

               
            }

            //task 4
            else if (taskNumber == "4")
            {
                Console.WriteLine("this task 4");
                Console.WriteLine("Please enter a number");
                var userInput1 = Console.ReadLine();
                decimal value1 = Convert.ToDecimal(userInput1);
                int multiplier = 0;
                for(int i = 0; i < 10; i++)
                {
                    multiplier += 1;
                    Console.WriteLine($"{value1} * {multiplier} = {value1 * multiplier}");
                }
            }

            //task 5

            else if (taskNumber == "5")
                {
                    Console.WriteLine("this task 4");
                    Console.WriteLine("Please enter a number");
                    var userInput1 = Console.ReadLine();
                    decimal value1 = Convert.ToDecimal(userInput1);
                    for (int i = 1; i < value1; i++)
                    {
                        if (i % 2 == 0)
                        {
                            Console.WriteLine($"{i * i}");
                        }
                    }
                }


            //exit
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