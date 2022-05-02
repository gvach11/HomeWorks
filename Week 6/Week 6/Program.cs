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

                // Task 1

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
        }
    }
    }
}


