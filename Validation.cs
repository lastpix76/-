using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace PlanetProject
{
	class Validation
	{
		public static Regex stringToParse { get; private set; } = new Regex(".+[ ].+[ ].+[ ].+[ ].+");

		public static Regex namePattern { get; private set; } = new Regex("^[A-z]{2,20}$");

		public static Regex distancePattern { get; private set; } = new Regex("^[1-9][0-9]{0,1}$");

		public static Regex diameterPattern { get; private set; } = new Regex("^[1-2][0-9][0-9][,|.]{0,1}[0-9]{0,3}$");

		public static string ValidationName(string name)
		{
			while (!namePattern.IsMatch(name))
			{
				Console.Beep();
				Console.WriteLine($"Invalid name ({name})");
				Console.WriteLine("Input it again: ");
				name = Console.ReadLine();
			}

			return name;
		}

		public static int ValidationDistance(string distance)
		{
			while (!distancePattern.IsMatch(distance))
			{
				Console.Beep();
				Console.WriteLine($"Invalid distance ({distance})");
				Console.WriteLine("Input it again: ");
				distance = Console.ReadLine();
			}
			return int.Parse(distance);
		}

		public static double ValidationDiameter(string diameter)
		{
			while (!diameterPattern.IsMatch(diameter))
			{
				Console.Beep();
				Console.WriteLine($"Invalid diameter ({diameter})");
				Console.WriteLine("Input it again: ");
				diameter = Console.ReadLine();
			}
			return double.Parse(diameter.Replace('.', ','));
		}

		public static string ValidationFile(string filename)
		{
			while(!File.Exists(@"C:\Users\M\Desktop\" + filename))
			{
				Console.Beep();
				Console.WriteLine("file doesn't exist!");
				filename = Console.ReadLine();
			}
			return filename;
		}

		public static string ValidationToParse(string strToParse)
		{
			while(!stringToParse.IsMatch(strToParse))
			{
				Console.Beep();
				Console.WriteLine("Inappropriate form!(name distance gender diameter email)");
				strToParse = Console.ReadLine();
			}

			return strToParse;
		}
	}
}