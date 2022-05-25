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
        public static string filepath = @"C:\task1.xml";
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
            int partSize = input.Length/partNumber;
            var indexCount = 0;
            resultList = new List<string>();
            foreach (char c in input)
            {
                if (partNumber == 1)
                {
                    resultList.Add(input);
                    foreach (string s in resultList)
                    {
                        Console.WriteLine(s);
                        return resultList;
                    }
                }
                else if (indexCount % partSize == 0)
                {
                    try
                    {
                        resultList.Add(input.Substring(indexCount, partSize));
                    }
                    catch(ArgumentOutOfRangeException)
                    {
                        resultList.Add(input.Substring(indexCount, (partSize-1)));
                    }
                }
                indexCount++;
                
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
        public void WriteXML(List<string> input)
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlNode root = xmldoc.DocumentElement;
            xmldoc.Load(XMLInitiator.filepath);
            var iterationCount = 1;
            foreach (string s in input)
            {
                XmlElement currentelement = xmldoc.CreateElement(s);
                currentelement.InnerText = $"String #{iterationCount}";
                xmldoc.DocumentElement.AppendChild(currentelement);
                iterationCount++;
            }
            xmldoc.Save(XMLInitiator.filepath);
        }
    }
}

