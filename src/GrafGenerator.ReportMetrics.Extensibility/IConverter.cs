using System;
using System.Globalization;

namespace GrafGenerator.ReportMetrics.Extensibility
{
	public interface IConverter
	{
		object ConvertFrom(object value, CultureInfo culture = null);
		object ConvertTo(object value, Type destinationType, CultureInfo culture = null);
	}
}