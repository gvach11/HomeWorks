using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Week_12
{
    public class MultiplicationFileWriter
    {
        public void WriteToFile(int input)
        {
            var lineIterator = new SingleLineFiller();
            for (int i = 1; i <= 10; i++)
            {
                lineIterator.multiplier = i;
                lineIterator.LineBuilder(input);
                File.AppendAllText(FileInitiator.filepath, "\n");



            }
            var streamreader = new StreamReader(FileInitiator.filepath);
            Console.WriteLine(streamreader.ReadToEnd());
        }
    }

    public class SingleLineFiller
    {
        int input { get; set; }
        public int multiplier { get; set; }
        public void LineBuilder(int input)
        {
            for (int i = 1; i <= input; i++)
            {
                File.AppendAllText(FileInitiator.filepath, $"{multiplier} * {i} = {multiplier * i} | ");
            }
        }


    }


}
