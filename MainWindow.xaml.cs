using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Maps.MapControl.WPF;

namespace SharkViz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
			DataContext = new ListeningStationViewModel();
            map.Focus();
        }

        private double ellipseDiameter = 200.0;

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            /*
            Ellipse ellipse = new Ellipse();
            ellipse.MaxHeight = ellipseDiameter;
            ellipse.MaxWidth = ellipseDiam///eter;
            ellipse.Height = ellipseDiameter;
            ellipse.Width = ellipseDiameter;
            
            var gradientStops = new GradientStopCollection();

            Color red = Brushes.Red.Color;
            red.A = 128;
            Color yellow = Brushes.Yellow.Color;
            yellow.A = 64;
            Color blue = Brushes.Blue.Color;
            blue.A = 0;

            gradientStops.Add(new GradientStop(red, 0.0));
            gradientStops.Add(new GradientStop(yellow, 0.50));
            //gradientStops.Add(new GradientStop(Brushes.Green.Color, 0.75));
            gradientStops.Add(new GradientStop(blue, 1.0));

            //gradientStops.Add(new GradientStop(Brushes.Red.Color, 0.0));
            //gradientStops.Add(new GradientStop(Brushes.Green.Color, 0.5));
            //gradientStops.Add(new GradientStop(Brushes.Blue.Color, 1.0));

            var brush = new RadialGradientBrush(gradientStops);
            //brush.ColorInterpolationMode = ColorInterpolationMode.ScRgbLinearInterpolation;

            ellipse.Fill = brush;
            //ellipse.Fill = new RadialGradientBrush(Color.FromArgb(128, 0, 0, 0), Color.FromArgb(0, 0, 0, 0));

            ellipse.SetValue(Canvas.LeftProperty, e.GetPosition(canvas).X - ellipseDiameter/2.0);
            ellipse.SetValue(Canvas.TopProperty, e.GetPosition(canvas).Y - ellipseDiameter/2.0);

            canvas.Children.Add(ellipse);  
            */
        }

		private void Ellipse_MouseEnter(object sender, MouseEventArgs e)
		{
			FrameworkElement pin = sender as FrameworkElement;
			var station = (ListeningStation)pin.Tag;

			MapLayer.SetPosition(ContentPopup, station.Location);
			MapLayer.SetPositionOffset(ContentPopup, new Point(20, -10));

			ContentPopupText.Text = station.ID;
			ContentPopupDescription.Text = station.Name;
			ContentPopup.Visibility = Visibility.Visible;
		}

		private void Ellipse_MouseLeave(object sender, MouseEventArgs e)
		{
			ContentPopup.Visibility = Visibility.Collapsed;
		}
    }
}
