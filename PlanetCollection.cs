using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace PlanetProject
{
	class PlanetCollection
	{
		private List<Planet> collection;
		public string filePath { get; set; }

		public PlanetCollection(string filePath)
		{
			this.collection = new List<Planet>();
			this.filePath = filePath;
		}

		public override string ToString()
		{
			string repr = "";

			foreach (Planet item in this.collection)
			{
				repr += item.ToString() + "\n";
			}

			return repr;
		}

		public void Add(Planet hum)
		{
			this.collection.Add(new Planet(hum));
			this.UpdateFile();
		}

		public List<Planet> Find(string id)
		{
			List<Planet> humLst = new List<Planet>();

			foreach (Planet Planet in this.collection)
			{
				if (Planet.ToString().ToLower().Contains(id.ToLower()))
				{
					humLst.Add(Planet);
				}
			}
			return humLst;
		}

		public void Update(string id, Planet newPlanet)
		{
			foreach (Planet Planet in this.collection)
			{
				if (Planet.ToString().ToLower().Contains(id.ToLower()))
				{
					int index = this.collection.IndexOf(Planet);

					this.collection.Insert(index, new Planet(newPlanet));
					this.collection.Remove(Planet);

					break;
				}
			}

			this.UpdateFile();
		}

		public void Remove(string id)
		{
			List<Planet> xxx = new List<Planet>();

			foreach (Planet Planet in this.collection)
			{
				if (Planet.ToString().ToLower().Contains(id.ToLower()))
				{
					xxx.Add(Planet);
				}
			}

			foreach (Planet item in xxx)
			{
				this.collection.Remove(item);
			}

			this.UpdateFile();
		}

		public void Sort(string crit)
		{
			try
			{
				this.collection = this.collection.OrderBy(p => p.GetType().GetProperty(crit).GetValue(p)).ToList();
			}
			catch
			{
				Console.WriteLine("Invalid input!");
				Console.ReadKey();
			}

			this.UpdateFile();
		}

		public void ReadFromFile()
		{
			string[] PlanetRepr = File.ReadAllLines(this.filePath);

			foreach (string item in PlanetRepr)
			{
				this.collection.Add(Planet.Parse(item));
			}

			this.UpdateFile();
		}

		public void UpdateFile()
		{
			File.WriteAllText(this.filePath, this.ToString());
		}

	}
}
