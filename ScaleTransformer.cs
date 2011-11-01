using System;
using System.Windows.Data;
using System.Windows.Media;

namespace SharkViz
{
	public class PushpinScaleTransform : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			double currentZoomLevel = (double)value;

			//double scaleVal = (0.05 * (currentZoomLevel + 1)) + 0.3;
			//double scaleVal = (0.01 * (currentZoomLevel + 1)) + 0.3;

			double scaleVal = Math.Pow(0.05 * (currentZoomLevel + 1), 2) + 0.01;
			if (scaleVal > 1) scaleVal = 1;
			if (scaleVal < 0.125) scaleVal = 0.125;

			return new ScaleTransform(scaleVal, scaleVal);
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
