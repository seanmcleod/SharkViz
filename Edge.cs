using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Microsoft.Maps.MapControl.WPF;
using System.Windows.Media;

namespace SharkViz
{
	public class Edge
	{
		public Edge(ListeningStation from, ListeningStation to, double value)
		{
			ID = from.ID + " - " + to.ID;
			Name = from.Name + " - " + to.Name;
			
			LocationCollection vertices = new LocationCollection();
			vertices.Add(from.Location);
			vertices.Add(to.Location);
			Vertices = vertices;

			Value = value;
		}

		public string ID { get; set; }
		public string Name { get; set; }
		public LocationCollection Vertices { get; set; }

		private double _value;
		public double Value 
		{
			get { return _value; }
			set
			{
				_value = value;

				// Map 0 - 100 to 5 to 20
				Width = (_value / 100.0) * 15.0 + 5.0;

				/*
				 * 0	- 0,0,255
				 * 20	- 0,200,255
				 * 40	- 0,255,106
				 * 60	- 99,255,0
				 * 80	- 255,207,0
				 * 100	- 255,5,0
				*/

				byte startAlpha = 255;
				byte endAlpha = 150;

				var gradientStops = new GradientStopCollection();

				if (_value == 0)
				{
					gradientStops.Add(new GradientStop(Color.FromArgb(startAlpha, 0, 0, 255), 0.0));
					gradientStops.Add(new GradientStop(Color.FromArgb(endAlpha, 0, 0, 255), 1.0));
				}
				else if (_value <= 20)
				{
					gradientStops.Add(new GradientStop(Color.FromArgb(startAlpha, 0, 200, 255), 0.0));
					gradientStops.Add(new GradientStop(Color.FromArgb(endAlpha, 0, 200, 255), 1.0));
				}
				else if (_value <= 40)
				{
					gradientStops.Add(new GradientStop(Color.FromArgb(startAlpha, 0, 255, 106), 0.0));
					gradientStops.Add(new GradientStop(Color.FromArgb(endAlpha, 0, 255, 106), 1.0));
				}
				else if (_value <= 60)
				{
					gradientStops.Add(new GradientStop(Color.FromArgb(startAlpha, 99, 255, 0), 0.0));
					gradientStops.Add(new GradientStop(Color.FromArgb(endAlpha, 99, 255, 0), 1.0));
				}
				else if (_value <= 80)
				{
					gradientStops.Add(new GradientStop(Color.FromArgb(startAlpha, 255, 207, 0), 0.0));
					gradientStops.Add(new GradientStop(Color.FromArgb(endAlpha, 255, 207, 0), 1.0));
				}
				else if (_value <= 100)
				{
					gradientStops.Add(new GradientStop(Color.FromArgb(startAlpha, 255, 5, 0), 0.0));
					gradientStops.Add(new GradientStop(Color.FromArgb(endAlpha, 255, 5, 0), 1.0));
				}

				Fill = new RadialGradientBrush(gradientStops);
			}
		}

		// Really view model properties
		public double Width { get; set; }
		public Brush Fill { get; set; }

	}

}