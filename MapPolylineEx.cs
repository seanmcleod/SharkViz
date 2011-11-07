using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Maps.MapControl.WPF;
using System.Windows;
using System.Windows.Media;

namespace SharkViz
{
    class MapPolylineEx : MapPolyline
    {
        public static readonly DependencyProperty StrokeProperty;
        public static readonly DependencyProperty StrokeThicknessProperty;

        static MapPolylineEx()
        {
            MapPolylineEx.StrokeProperty = DependencyProperty.Register("Stroke", typeof(Brush), typeof(MapPolylineEx),
                    new FrameworkPropertyMetadata(Brushes.Black, OnStrokeExChanged));

            MapPolylineEx.StrokeThicknessProperty = DependencyProperty.Register("StrokeThickness", typeof(double), typeof(MapPolylineEx),
                    new FrameworkPropertyMetadata(1.0, OnStrokeThicknessExChanged));
        }

		public new Brush Stroke
		{
            get { return (Brush)GetValue(MapPolylineEx.StrokeProperty); }
            set { SetValue(MapPolylineEx.StrokeProperty, value); }
        }

        private static void OnStrokeExChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            (o as MapPolyline).Stroke = (Brush)e.NewValue;
        }

        public new double StrokeThickness
        {
            get { return (double)GetValue(MapPolylineEx.StrokeThicknessProperty); }
            set { SetValue(MapPolylineEx.StrokeThicknessProperty, value); }
        }

        private static void OnStrokeThicknessExChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            (o as MapPolyline).StrokeThickness = (double)e.NewValue;
        }
    }
}
