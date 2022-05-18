using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_10
{
    public class TaskChooser
    {
        string input { get; set; }

        public static void Chooser(string input) 
        {
            if (input == "1")
            {
                Console.WriteLine("Please enter the file extension");
                var extension = Console.ReadLine();
                Console.WriteLine("Please enter max size");
                var maxSize = Convert.ToInt32(Console.ReadLine());
                FileWorkerExecute.Read(extension, maxSize);
                FileWorkerExecute.Write(extension, maxSize);
                FileWorkerExecute.Edit(extension, maxSize);
                FileWorkerExecute.Delete(extension, maxSize);
            }
        }
    }
}
