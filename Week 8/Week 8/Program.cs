using System;
using System.Collections.Generic;
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
            //Task 1
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
            //Task 2
            if (taskInput == "2")
            {
                Console.WriteLine("Please enter the list of characters to check for pairs");
                string inputString = Console.ReadLine();
                var outputString = Task2(inputString);
                Console.WriteLine($"There are {outputString} pairs in your string");
            }
            //Task 3
            if (taskInput == "3")
            {
                Console.WriteLine("Please input string #1");
                string stringOne = Console.ReadLine();
                Console.WriteLine("Please enter string #2");
                string stringTwo = Console.ReadLine();
                Console.WriteLine($"The common last characters are: {Task3(stringOne, stringTwo)}");
            }
            //Task 4
            if (taskInput == "4")
            {
                Console.WriteLine("What sort of list would you like? [1] - String, [2] - Integer, [3] - Boolean");
                var arrayChoice = Console.ReadLine();
                if (arrayChoice == "1")
                {
                    var stringlist = new List<string>();
                    Console.WriteLine("How many elements would you like?");
                    int elementChoice = Convert.ToInt32(Console.ReadLine());
                    for(int i = 0; i < elementChoice; i++)
                    {
                        Console.WriteLine($"Please enter element {i + 1}");
                        stringlist.Add(Console.ReadLine());
                    }

                    Task4(stringlist);
                }
                if (arrayChoice == "2")
                {
                    var intlist = new List<int>();
                    Console.WriteLine("How many elements would you like?");
                    int elementChoice = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < elementChoice; i++)
                    {
                        Console.WriteLine($"Please enter element {i + 1}");
                        intlist.Add(Convert.ToInt32(Console.ReadLine()));
                    }

                    Task4(intlist);
                }
                if (arrayChoice == "3")
                {
                    var boollist = new List<bool>();
                    Console.WriteLine("How many elements would you like?");
                    int elementChoice = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < elementChoice; i++)
                    {
                        Console.WriteLine($"Please enter element {i + 1}, [1] for true, [0] for false");
                        var boolinput = Console.ReadLine();
                        if (boolinput == "1") { boollist.Add(true); }
                        if (boolinput == "0") { boollist.Add(false); }
                        
                    }
                    Task4(boollist);
                }
                
            }
            //Task 5
            if (taskInput == "5")
            {
                Console.WriteLine("Enter a number");
                int num = Convert.ToInt32(Console.ReadLine());
                Task5(num);
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

        static void Task4<T>(List<T> someList) 
        {

           
            if (typeof(T) == typeof(string))
            {
                foreach(var item in someList) {
                    var itemUpper = item.ToString().ToUpper();
                    Console.WriteLine(itemUpper); }
            }
            if (typeof(T) == typeof(int))
            {
                int sum = 0;
                foreach (var item in someList)
                {
                    sum += Convert.ToInt32(item); 
                    
                }
                Console.WriteLine(sum);
            }
            if (typeof (T) == typeof(bool))
            {
                Console.WriteLine($"The first element is {someList[0]}");
                Console.WriteLine($"The middle element is {someList[someList.Count/2]}");
                Console.WriteLine($"The last element is {someList[someList.Count-1]}");
            }

            
        }


        static void Task5(int a)
        {
            string converted = Convert.ToString(a);
            Console.Write($"{converted.Substring(0, 1)}-");
            converted = converted.Substring(1, converted.Length-1);
            if (converted.Length >1)
            {
                int reconverted = Convert.ToInt32(converted);
                Task5(reconverted);
            }
            else if(converted.Length > 0) 
            {
                int reconverted = Convert.ToInt32(converted);
                Console.Write($"{converted.Substring(0, 1)}");
                Console.WriteLine("\n");
            }
            



        }      
    }
}

