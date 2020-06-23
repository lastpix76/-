using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetProject
{
	class Planet
	{
		public string name { get; private set; }
		public int distance { get; private set; }
		public double diameter { get; private set; }
		public Planet()
		{

		}
		public Planet(string s)
		{
			Planet a = Planet.Parse(s);
			this.name = a.name;
			this.distance = a.distance;
			this.diameter = a.diameter;
		}
		public Planet(string n = "unknown", int dist = 1, double diam = 111.0)
		{
			this.name = Validation.ValidationName(n);
			this.distance = Validation.ValidationDistance(dist.ToString());
			this.diameter = Validation.ValidationDiameter(diam.ToString());
		}

		public Planet(Planet pl)
		{
			this.name = pl.name;
			this.distance = pl.distance;
			this.diameter = pl.diameter;
		}

		public override string ToString()
		{
			string repr = "";
			repr += this.name + "\t";
			repr += this.distance + "\t";
			repr += this.diameter + "\t";
			return repr;
		}

		public static Planet Parse(string repr)
		{
			repr = Validation.ValidationToParse(repr.Replace('\t',' '));
			string[] repr_div = repr.Split();

			Planet pl = new Planet();

			pl.name = Validation.ValidationName(repr_div[0]);
			pl.distance = Validation.Validationdistance(repr_div[1]);
			pl.gender = Validation.ValidationGender(repr_div[2]);
			pl.diameter = Validation.Validationdiameter(repr_div[3]);
			pl.email = Validation.ValidationEmail(repr_div[4]);

			return pl;
		}
	}
}