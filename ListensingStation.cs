using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Microsoft.Maps.MapControl.WPF;
using System.Windows.Media;

namespace SharkViz
{
	public class ListeningStation
	{
		public string ID { get; set; }
		public string Name { get; set; }
		public Location Location { get; set; }

		private double _value;
		public double Value 
		{
			get { return _value; }
			set
			{
				_value = value;

				// Map 0 - 100 to 25 to 75
				Diameter = (_value / 100.0) * 50.0 + 25.0;

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
		public double Diameter { get; set; }
		public Brush Fill { get; set; }
	}

}