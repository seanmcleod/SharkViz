using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Microsoft.Maps.MapControl.WPF;

namespace SharkViz
{
	public class Edge
	{
		public Edge(ListeningStation from, ListeningStation to)
		{
			ID = from.ID + " - " + to.ID;
			Name = from.Name + " - " + to.Name;
			
			LocationCollection vertices = new LocationCollection();
			vertices.Add(from.Location);
			vertices.Add(to.Location);
			Vertices = vertices;
		}

		public string ID { get; set; }
		public string Name { get; set; }
		public LocationCollection Vertices { get; set; }

		public double Value { get; set; }
	}

}