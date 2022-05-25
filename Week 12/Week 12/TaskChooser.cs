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
                Console.WriteLine("Please input the number of lines");
                var lineNumber = Convert.ToInt32(Console.ReadLine());
                FileInitiator fileInitiator = new FileInitiator();
                FileWriter fileWriter = new FileWriter();
                fileInitiator.CreateOrClear();
                fileWriter.WriteToFile(lineNumber);
                
            }
            if (input == "2")
            {
                Console.WriteLine("Please input a whole number");
                var number = Convert.ToInt32(Console.ReadLine());
                FileInitiator fileInitiator = new FileInitiator();
                var fileWriter = new MultiplicationFileWriter();
                fileInitiator.CreateOrClear();
                fileWriter.WriteToFile(number);
            }

            if (input == "3")
            {
                var xmlwriter = new XMLWriter();
                var xmlinitiator = new XMLInitiator();
                Console.WriteLine("Please input a string");
                var stringSplitter = new StringSplitter();
                stringSplitter.input = Console.ReadLine();
                Console.WriteLine("Please enter the number in which the string should be divided");
                stringSplitter.partNumber = Convert.ToInt32(Console.ReadLine());
                xmlinitiator.CreateOrClear();
                xmlwriter.WriteXML(stringSplitter.SplitString(stringSplitter.input, stringSplitter.partNumber));


            }
            if (input == "4")
            {
                JSONInitiator initiator = new JSONInitiator();
                Parser parser = new Parser();
                initiator.CreateOrClear();
                initiator.RandomJsonData();
                parser.JsonParse();
            }
        }
    }
}