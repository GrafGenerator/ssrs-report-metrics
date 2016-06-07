using System;
using System.ComponentModel;
using System.Globalization;
using GrafGenerator.ReportMetrics.Extensibility;

namespace GrafGenerator.ReportMetrics.ReportingServices.Auxiliary
{
	class ReportFormatConverter : IConverter
	{
		public object ConvertFrom(object value, CultureInfo culture = null)
		{
			var s = value as string;
			if(s != null)
			{
				switch (s.ToLowerInvariant())
				{
					case "html4.0":
						return ReportRenderFormat.Html;
					case "excel":
						return ReportRenderFormat.Excel;
					case "pdf":
						return ReportRenderFormat.Pdf;

					default:
						return ReportRenderFormat.Unknown;
				}
			}

			return null;
		}

		public object ConvertTo(object value, Type destinationType, CultureInfo culture = null)
		{
			if (destinationType == typeof (string))
			{
				var format = (ReportRenderFormat) value;

				switch (format)
				{
					case ReportRenderFormat.Excel:
						return "EXCEL";

					case ReportRenderFormat.Html:
						return "HTML4.0";

					case ReportRenderFormat.Pdf:
						return "PDF";

					default:
						return "UNKNOWN";
				}
			}

			return null;
		}
	}
}
