using System;
using System.Collections.Generic;
using System.IO;

namespace PlanetProject
{
	class Program
	{
		static void Menu()
		{
			Console.WriteLine("Read:\t1");
			Console.WriteLine("Add:\t2");
			Console.WriteLine("Sort:\t3");
			Console.WriteLine("Remove:\t4");
			Console.WriteLine("Find:\t5");
			Console.WriteLine("Update:\t6");
		}
		static void Main(string[] args)
		{
			Console.WriteLine("Filename: ");
			string filename = Validation.ValidationFile(Console.ReadLine());
			Collection<Planet> plCollection = new Collection<Planet>(@"C:\Users\M\Desktop\" + filename);

			while (true)
			{
				Menu();
				string choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
						plCollection.ReadFromFile();
						break;

					case "2":
						plCollection.Add(Planet.Parse(Console.ReadLine()));
						break;

					case "3":
						Console.WriteLine("Criteria: ");
						string crit = Console.ReadLine();
						plCollection.Sort(crit);
						break;

					case "4":
						Console.WriteLine("id: ");
						string crit2 = Console.ReadLine();
						plCollection.Remove(crit2);
						break;

					case "5":
						Console.WriteLine("id: ");
						string crit3 = Console.ReadLine();
						List<Planet> result = plCollection.Find(crit3);

						foreach (Planet item in result)
						{
							Console.WriteLine(item.ToString());
						}

						Console.ReadKey();
						break;

					case "6":
						Console.WriteLine("id: ");
						string crit4 = Console.ReadLine();
						Planet newpl = Planet.Parse(Console.ReadLine());
						plCollection.Update(crit4, newpl);
						break;

					default:
						break;
				}

				Console.Clear();
				Console.WriteLine(plCollection.ToString());

			}

		}

	}

}