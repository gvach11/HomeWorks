using System;
using System.Linq;

namespace Week_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please enter the number of task from 1 to 5, or 0 to exit");
                var taskNumber = Console.ReadLine();
                if (taskNumber == "1" || taskNumber == "2" || taskNumber == "3" || taskNumber == "4" || taskNumber == "5")
                {
                    TaskChooser(taskNumber);
                }
                if (taskNumber == "0") { break; }
            }
        }
            static void TaskChooser(string taskInput)
            {
            if (taskInput == "1")
            {
                Console.WriteLine("Please enter a");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter b");
                int b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter n");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(Task1(a, b, n));
            }
            if (taskInput == "2")
            {
                Console.WriteLine("Please enter the list of characters to check for pairs");
                string inputString = Console.ReadLine();
                var outputString = Task2(inputString);
                Console.WriteLine($"There are {outputString} pairs in your string");
            }
            if (taskInput == "3")
            {
                Console.WriteLine("Please input string #1");
                string stringOne = Console.ReadLine();
                Console.WriteLine("Please enter string #2");
                string stringTwo = Console.ReadLine();
                Console.WriteLine(Task3(stringOne, stringTwo));
            }
            if (taskInput == "4")
            {

            }

            }

            static int Task1(int a, int b, double n)
            {
                int count = 0;
                int result = 0;
                while (Math.Pow(count, n) <= b)
                {

                    if (Math.Pow(count, n) >= a)
                    {
                        result++;
                    };
                    count++;



                }
                return result;


            }

            static int Task2(string a)
            {

                var pairCheck = from x in a
                                group x by x into y
                                select y.Count();
                var result = 0;
                foreach (var x in pairCheck) 
                {
                    result += x / 2;
                    
                }
                return result;
            }

            static string Task3(string a, string b)
            {
            string result = "";
            if (a.Length > b.Length){
                for (int i = 0; i < b.Length; i++)
                {
                    if (a[a.Length-1-i] == b[b.Length - 1 - i])
                    {

                        result +=(a[a.Length - 1 - i]);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (b[b.Length - 1 - i] == a[a.Length - 1 - i])
                    {
                       
                        result += (b[b.Length - 1 - i]);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            string endResult = new string(result.Reverse().ToArray());

            return endResult;
            }
        
    }
}

