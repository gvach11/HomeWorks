using System;

namespace Week_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please enter the number of task from 1 to 2, or 0 to exit");
                var taskNumber = Console.ReadLine();
                if (taskNumber == "1" || taskNumber == "2" || taskNumber == "3")
                {
                    TaskChooser.Chooser(taskNumber);
                }
                if (taskNumber == "0") { break; }
            }

            


        }
    }
}
