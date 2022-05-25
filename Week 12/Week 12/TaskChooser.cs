using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_12
{
    public class TaskChooser
    {
        string input { get; set; }

        public static void Chooser(string input)
        {
            if (input == "1")
            {
                Console.WriteLine("Please inpu the number of lines");
                var lineNumber = Convert.ToInt32(Console.ReadLine());
                Task1 fileworker = new Task1();
                fileworker.CreateOrClear();
                fileworker.WriteToFile(lineNumber);
                
            }
        }
    }
}