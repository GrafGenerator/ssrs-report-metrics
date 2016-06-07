using System.IO;
using GrafGenerator.ReportMetrics.ReportingServices.Auxiliary;
using GrafGenerator.ReportMetrics.ReportingServices.Connection;

namespace GrafGenerator.ReportMetrics.ReportingServices.ReportAccessWrappers
{
	public class ReportWrapper
	{
		private readonly string _reportPath;
		private string _sessionId;

		private ReportWrapper(ServerConnection connection, string reportPath)
		{
			_reportPath = reportPath;

			var rs = connection.ExecutionService;
			rs.ExecutionHeaderValue = new ExecutionHeader();

			_sessionId = rs.ExecutionHeaderValue.ExecutionID;
		}


		public Stream Render(ReportRenderFormat format, ParamPack parameters)
		{
			return null;
		}

		public ReportWrapper Create(ServerConnection connection, string reportPath)
		{
			return new ReportWrapper(connection, reportPath);
		}
	}
}
