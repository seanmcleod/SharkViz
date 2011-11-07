using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Microsoft.Maps.MapControl.WPF;
using System.Windows.Media;
using System.Windows;

namespace SharkViz 
{
    public class Edge : DependencyObject
	{
        public static readonly DependencyProperty ValueProperty;

        static Edge()
        {
                Edge.ValueProperty = DependencyProperty.Register("Value", typeof(double), typeof(Edge),
                    new FrameworkPropertyMetadata(0.0, OnValueChanged));
        }

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

        private static void OnValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            (o as Edge).ValueChanged((double)e.NewValue);
        }

        public double Value
        {
            get { return (double)GetValue(Edge.ValueProperty); }
            set { SetValue(Edge.ValueProperty, value); }
        }

        private void ValueChanged(double _value)
		{
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

		// Really view model properties
		public double Width { get; set; }
		public Brush Fill { get; set; }

	}

}