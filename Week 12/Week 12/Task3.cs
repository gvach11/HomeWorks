using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace Week_12
{
    public class XMLInitiator
    {
        public static string filepath = @"C:\task3.xml";
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

    public class StringSplitter
    {
        public string input { get; set; }
        public int partNumber { get; set; }
        public List<string> resultList { get; set; }

        public List<string> SplitString(string input, int partNumber)
        {
            int partSize = input.Length / partNumber;
            var indexCount = 0;
            resultList = new List<string>();
            if(input.Length%partNumber != 0)
            {
                Console.WriteLine($"The string can't be divided into {partNumber} equal parts.");
            }
            else
            {
                foreach (char c in input)
                {
                    if (partNumber == 1)
                    {
                        resultList.Add(input);
                        return resultList;
                    }
                    else if (indexCount % partSize == 0)
                    {
                        resultList.Add(input.Substring(indexCount, partSize));
                    }
                    indexCount++;
                }
            }
            
            //test
            foreach (string s in resultList)
            {
                Console.WriteLine(s);

                //test

            }
            
            return resultList;

        }
    }

    public class XMLWriter
    {
        public void WriteToXML(List<string> input)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<item><name>Root</name></item>");
            XmlNode root = doc.DocumentElement;
            XmlTextWriter writer = new XmlTextWriter(XMLInitiator.filepath, null);
            writer.Formatting = Formatting.Indented;
            var iterationcount = 1;
            foreach (string s in input)
            {
                XmlElement currentelement = doc.CreateElement(s);
                currentelement.InnerText = $"<string{iterationcount}>";
                root?.InsertAfter(currentelement, root.LastChild);
                iterationcount++;
            }
            doc.Save(writer);
            
        }
    }
}




