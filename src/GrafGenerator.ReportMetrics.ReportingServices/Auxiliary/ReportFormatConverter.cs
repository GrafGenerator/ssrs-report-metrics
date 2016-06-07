using System;
using System.ComponentModel;
using System.Globalization;

namespace GrafGenerator.ReportMetrics.ReportingServices.Auxiliary
{
	class ReportFormatConverter: TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType == typeof (string))
				return true;

			return base.CanConvertFrom(context, sourceType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
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

			return base.ConvertFrom(context, culture, value);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
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

			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}
