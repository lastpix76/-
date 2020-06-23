using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Reflection;

namespace PlanetProject
{
	class Collection<T> where T: new()
	{
		private List<T> collection;
		public string filePath { get; set; }

		public Collection(string filePath)
		{
			this.collection = new List<T>();
			this.filePath = filePath;
		}

		public override string ToString()
		{
			string repr = "";

			foreach (T item in this.collection)
			{
				repr += item.ToString() + "\n";
			}

			return repr;
		}

		public void Add(T item)
		{
			this.collection.Add(item);
			this.UpdateFile();
		}

		public List<T> Find(string id)
		{
			List<T> itemLst = new List<T>();

			foreach (T item in this.collection)
			{
				if (item.ToString().ToLower().Contains(id.ToLower()))
				{
					itemLst.Add(item);
				}
			}
			return itemLst;
		}

		public void Update(string id, T newItem)
		{
			foreach (T item in this.collection)
			{
				if (item.ToString().ToLower().Contains(id.ToLower()))
				{

					int index = this.collection.IndexOf(item);

					this.collection.Insert(index, newItem);
					this.collection.Remove(item);

					break;
				}
			}

			this.UpdateFile();
		}

		public void Remove(string id)
		{
			List<T> xxx = new List<T>();

			foreach (T item in this.collection)
			{
				if (item.ToString().ToLower().Contains(id.ToLower()))
				{
					xxx.Add(item);
				}
			}

			foreach (T item in xxx)
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
				this.collection.Add((T)Activator.CreateInstance(typeof(T), item));
			}

			this.UpdateFile();
		}

		public void UpdateFile()
		{
			File.WriteAllText(this.filePath, this.ToString());
		}
	}
}