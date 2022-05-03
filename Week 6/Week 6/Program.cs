using System;
using System.Linq;

namespace Week_6
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            while (true) {
                //task chooser

                Console.WriteLine("Please select a task from 1 to 3, or type 0 to exit");
                var taskNumber = Console.ReadLine();

                //task 1

                if (taskNumber == "1") {

                    Console.WriteLine("This is task 1");
                    Console.WriteLine("Please enter a number");
                    var arraySize = Convert.ToInt32(Console.ReadLine());
                    var inputArray = new int [arraySize];
                    int oddArraySize = 0;
                    int evenArraySize = 0;
            
                    for (int i = 0; i < inputArray.Length; i++)
                    {
                        inputArray[i] = i+1;

                        if ((i+1) % 2 == 1){
                            oddArraySize++;
                        }
                        else
                        {
                            evenArraySize++;
                  
                        }
                    }

                    var evenArray = new int[evenArraySize];
                    var oddArray = new int[oddArraySize];
          
                    //even array

                    var count = 0;
                    foreach (int i in inputArray)
                    {
                        if (i % 2 == 0)
                        {
                            evenArray[count] = i;
                            count+=1;
                        }
                    }

                    count = 0;

                    Console.Write("Array #1: ");
                    foreach (var c in evenArray) {
                
                        Console.Write(c);
                        Console.Write(" ");
                    }
                    Console.WriteLine("");
                    //odd array

                    foreach (int i in inputArray)
                    {

                        if (i % 2 == 1)
                        {
                            oddArray[count] = i;
                            count += 1;
                        }
                    }

                    Console.Write("Array #2: ");
                    foreach (var c in oddArray) {
               
                        Console.Write(c);
                        Console.Write(" ");
                    }
                    Console.WriteLine("");

                }

                //task 2
                if (taskNumber == "2")
                {
                    Console.WriteLine("This is task 2");
                    Console.WriteLine("Please enter array length");
                    var inputArrayLength = Convert.ToInt32(Console.ReadLine());
                    var inputArray = new int[inputArrayLength];
                    for (int i = 0; i < inputArrayLength; i++)
                    {
                        Console.WriteLine("Please enter array elements");
                        inputArray[i] = Convert.ToInt32(Console.ReadLine());
                    }
                    var freq = from i in inputArray   //ეს რა პრინციპით მოქმედებს ვერ მივხვდი
                               group i by i into x
                               select x;
                    foreach (var element in freq) 
                    {
                        Console.WriteLine($"{element.Key} appears {element.Count()} times, sum is {element.Key * element.Count()}"); 
                    }
                    


                }

                //task 3
                if (taskNumber == "3")
                {
                    Console.WriteLine("This is task 3");
                    Console.WriteLine("Please enter how many final elements you wish to see");
                    var numOfElements = Convert.ToInt32(Console.ReadLine());
                    var task3Array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                    var result = task3Array.Skip(task3Array.Length - numOfElements);
                    Console.Write($"The last {numOfElements} elements are: ");
                    foreach (var x in result)
                    {
                        Console.Write($"{x} ");
                    }
                    Console.WriteLine("");
                }

                //exit
                if (taskNumber == "0") { break; }


        }
    }
    }
}


