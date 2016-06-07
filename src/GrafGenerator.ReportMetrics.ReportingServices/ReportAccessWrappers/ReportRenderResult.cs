using System.IO;
using GrafGenerator.ReportMetrics.Extensibility;

namespace GrafGenerator.ReportMetrics.ReportingServices.ReportAccessWrappers
{
	public class ReportRenderInfo
	{
		public Stream Stream { get; private set; }
		public ReportDiagnosticsInfo DiagnosticsInfo { get; set; }


		private ReportRenderInfo(Stream stream, ReportDiagnosticsInfo diagInfo)
		{
			Stream = stream;
			DiagnosticsInfo = diagInfo;
		}


		public static ReportRenderInfo Create(Stream stream, ReportDiagnosticsInfo diagInfo)
		{
			return new ReportRenderInfo(stream, diagInfo);
		}
	}
}
