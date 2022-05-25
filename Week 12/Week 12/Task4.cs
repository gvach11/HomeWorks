using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Week_12
{
    public class JSONInitiator
    {
        public static string filepath = @"C:\task4.json";
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

        public void RandomJsonData()
        {
            Random gen = new Random();

            DateTime RandomDay()
            {
                DateTime start = new DateTime(2022, 1, 1);
                int range = (DateTime.Today - start).Days;
                return DateTime.Today.AddDays(gen.Next(range));

            }


            string data = $"{{\"currentDate\": \"{DateTime.Now}\", \"BDdate\": \"{RandomDay()}\"}}";
            File.WriteAllText(JSONInitiator.filepath, data);
            Console.WriteLine(data);
        }
        
    }

    public class JSONClass
    {
        public string CurrentDate { get; set; }
        public string BDdate { get; set; }
    }

    public class Parser
    {
        public void JsonParse()
        {
            StreamReader r = new StreamReader(JSONInitiator.filepath);
            string jsonString = r.ReadToEnd();
            JSONClass fileContents = JsonConvert.DeserializeObject<JSONClass>(jsonString);
            var diff = Convert.ToDateTime(fileContents.BDdate) - Convert.ToDateTime(fileContents.CurrentDate);
            Console.WriteLine($"{diff.Days} days util birthday");
        }
}
}
