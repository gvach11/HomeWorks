using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Week_12
{
    public class FileInitiator
    {
        public static string filepath = @"C:\task1.txt";
        public void CreateOrClear()
        {
            if (!File.Exists(filepath))
            {
                var myfile = File.Create(filepath);
                myfile.Close();
            }
            else
            {
                File.WriteAllText(filepath, String.Empty);
            }
        }
        
    }

    public class FileWriter
    {
        public void WriteToFile(int lineNumber)
        {
            for (int i = 0; i < lineNumber; i++)
            {
                File.AppendAllText(FileInitiator.filepath, $"This is line #{(i + 1).ToString()}\n");
            }
            Console.WriteLine(File.ReadLines(FileInitiator.filepath).Last());

        }
    }
}
