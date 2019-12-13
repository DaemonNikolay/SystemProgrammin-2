using System;
using System.Collections.Generic;
using System.Linq;

namespace Task7
{
	class Program
	{
		static void Main(string[] args)
		{
			var docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			var filename = "code.txt";

			string[] lines = System.IO.File.ReadAllLines($"{docPath}/{filename}");
			var dict = new Dictionary<string, string>();


			foreach (string line in lines)
			{
				if (line[0] != ';')
				{
					break;
				}

				if (line[2] == '!' && line[3] == '!')
				{
					Print(line);
				}
				else if (line.Contains("const string") && line.Contains("= \""))
				{
					dict = AddNewValueForConstString(dict, line);
				}
				else if (line.Contains("const string") && line.Contains("*"))
				{
					dict = AddNewValueForRepeat(dict, line);
				}
				else if (line.Contains("int") && !line.Contains("^"))
				{
					dict = AddNewValueForInt(dict, line);
				}
				else if (line.Contains("int") && line.Contains("^"))
				{
					dict = AddNewValueForIntPow(dict, line);
				}
			}
		}

		private static void Print(string line)
		{
			Console.WriteLine(line.Split("!!")[1]);
		}

		private static Dictionary<string, string> AddNewValueForConstString(Dictionary<string, string> dict, string line)
		{
			dict[line.Split(' ')[3]] = line.Split("\"")[1];

			return dict;
		}

		private static Dictionary<string, string> AddNewValueForRepeat(Dictionary<string, string> dict, string line)
		{
			var elem = line.Split(" ")[5];
			var countRepeat = int.Parse(line.Split(" ")[7]);

			dict[line.Split(' ')[3]] = string.Concat(Enumerable.Repeat(dict[elem], countRepeat));

			return dict;
		}

		private static Dictionary<string, string> AddNewValueForInt(Dictionary<string, string> dict, string line)
		{
			dict[line.Split(' ')[2]] = line.Split(' ')[4];

			return dict;
		}

		private static Dictionary<string, string> AddNewValueForIntPow(Dictionary<string, string> dict, string line)
		{
			var expression = line.Split(' ')[4];
			var elem = double.Parse(dict[expression.Split('^')[0]]);
			var pow = double.Parse(expression.Split('^')[1]);

			dict[line.Split(' ')[2]] = Math.Pow(elem, pow).ToString();

			return dict;
		}
	}
}

// Example code 
//
//; !!nkbdfnkgbndfso!!
//; const string str = "123"
//; const string str1 = str * 5
//; int number1 = 5
//; int number2 = number1^3
