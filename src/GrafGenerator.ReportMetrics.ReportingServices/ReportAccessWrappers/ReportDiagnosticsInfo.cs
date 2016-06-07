using System;

namespace GrafGenerator.ReportMetrics.ReportingServices.ReportAccessWrappers
{
	public class ReportDiagnosticsInfo
	{
		public string SessionId { get; set; }
		public DateTime ExecutionDateTime { get; set; }
		public Warning[] Warnings { get; set; }
	}
}
