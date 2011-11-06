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
        public static readonly DependencyProperty StrokeExProperty;
        public static readonly DependencyProperty StrokeThicknessExProperty;

        static MapPolylineEx()
        {
            MapPolylineEx.StrokeExProperty = DependencyProperty.Register("StrokeEx", typeof(Brush), typeof(MapPolylineEx),
                    new FrameworkPropertyMetadata(Brushes.Black, OnStrokeExChanged));

            MapPolylineEx.StrokeThicknessExProperty = DependencyProperty.Register("StrokeThicknessEx", typeof(double), typeof(MapPolylineEx),
                    new FrameworkPropertyMetadata(1.0, OnStrokeThicknessExChanged));
        }

		public Brush StrokeEx 
		{
            get { return (Brush)GetValue(MapPolylineEx.StrokeExProperty); }
            set { SetValue(MapPolylineEx.StrokeExProperty, value); }
        }

        private static void OnStrokeExChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            (o as MapPolylineEx).Stroke = (Brush)e.NewValue;
        }

        public double StrokeThicknessEx
        {
            get { return (double)GetValue(MapPolylineEx.StrokeThicknessExProperty); }
            set { SetValue(MapPolylineEx.StrokeThicknessExProperty, value); }
        }

        private static void OnStrokeThicknessExChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            (o as MapPolylineEx).StrokeThickness = (double)e.NewValue;
        }
    }
}
