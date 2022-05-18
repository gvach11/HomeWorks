using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_10
{
    public abstract class FileWorker
    {
        int maxFileSize { get; set; }
        abstract public string extension { get; set; }

        public abstract void Read();
        public abstract void Write();
        public abstract void Edit();
        public abstract void Delete();
        

    }
    public class FileWorkerExecute : FileWorker
    {
        public override string extension { get; set; }

        public override void Delete()
        {
        }
        public static void Delete(string inputstring, int inputint)
        {
            Console.WriteLine($"I can read from {inputstring} file with max storage of {inputint} ");
        }

        public override void Edit()
        {
        }

        public static void Edit(string inputstring, int inputint)
        {
            Console.WriteLine($"I can edit {inputstring} file with max storage of {inputint} ");
        }

        public override void Read() 
        {
        }
        public static void Read(string inputstring, int inputint)
        {
            Console.WriteLine($"I can read from {inputstring} file with max storage of {inputint} ");
        }

        public override void Write()
        {
        }

        public static void Write(string inputstring, int inputint)
        {
            Console.WriteLine($"I can write to {inputstring} file with max storage of {inputint} ");

        }
    }
}
