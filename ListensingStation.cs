using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Microsoft.Maps.MapControl.WPF;

namespace SharkViz
{
	public class ListeningStation
	{
		public string ID { get; set; }
		public string Name { get; set; }
		public Location Location { get; set; }

		public double Value { get; set; }
	}

}