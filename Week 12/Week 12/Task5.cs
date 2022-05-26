using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json.Linq;

namespace Week_12
{

	public class CaesarInitiator
	{
		public static string filepath = @"C:\task5.json";
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

		public string CeasarData(int input)
		{
			string data = $"{{\"word\":\"ABCDEFGHIJKLMNOPQRSTUVWXYZ\", \"key\":\"{input}\"}}";
			File.WriteAllText(filepath, data);
			return "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		}
	}


        public class CaesarCipher
    {
		public static char Cipher(char ch, int key)
		{
			if (!char.IsLetter(ch))
				return ch;

			char offset = char.IsUpper(ch) ? 'A' : 'a';
			return (char)((((ch + key) - offset) % 26) + offset);
		}

		public string Encipher(string input, int key)
		{
			string output = string.Empty;

			foreach (char ch in input)
				output += Cipher(ch, key);

			return output;
		}
	}

	public class CaesarParser
	{
		public void CaesarParse(string input)
		{
			StreamReader r = new StreamReader(CaesarInitiator.filepath);
			string jsonString = r.ReadToEnd();
			//CaesarClass fileContents = JsonConvert.DeserializeObject<CaesarClass>(jsonString);
			//CaesarCipher cipher = new CaesarCipher();
            //string newword = cipher.Encipher(fileContents.word, Convert.ToInt32(fileContents.key));
            JObject jobject = JsonConvert.DeserializeObject(jsonString) as JObject;
			JToken jToken = jobject.SelectToken("word");
			jToken.Replace(input);
			string updatedjsonstring = jobject.ToString();
			File.WriteAllText(CaesarInitiator.filepath, updatedjsonstring);
			
			//Console.WriteLine(fileContents.word);
		}
	}

	public class CaesarClass
	{
		public string word { get; set; }
		public string key { get; set; }
	}
}
