using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Services.Protocols;
using GrafGenerator.ReportMetrics.Extensibility;
using GrafGenerator.ReportMetrics.ReportingServices.Auxiliary;
using GrafGenerator.ReportMetrics.ReportingServices.Connection;

namespace GrafGenerator.ReportMetrics.ReportingServices.ReportAccessWrappers
{
	public class ReportWrapper
	{
		private readonly ServerConnection _connection;
		private readonly ReportDiagnosticsInfo _diagInfo;

		private ReportWrapper(ServerConnection connection, string reportPath)
		{
			_connection = connection;

			var rs = _connection.ExecutionService;
			_diagInfo = new ReportDiagnosticsInfo();

			rs.ExecutionHeaderValue = new ExecutionHeader();
			rs.LoadReport(reportPath, null);

			_diagInfo.SessionId = rs.ExecutionHeaderValue.ExecutionID;
		}


		public Result<ReportRenderInfo> Render(ReportRenderFormat format, IEnumerable<ParameterValue> parameters)
		{
			var rs = _connection.ExecutionService;
			byte[] result;

			try
			{
				string mimeType, encoding, extension;
				Warning[] warnings;
				string[] streamIds;

				var formatString = new ReportFormatConverter().ConvertTo(format, typeof(string)) as string;


				rs.SetExecutionParameters(parameters.ToArray(), "en-us");

				result = rs.Render(formatString, null, out extension, out encoding, out mimeType, out warnings, out streamIds);
				_diagInfo.Warnings = warnings ?? new Warning[0];

				var execInfo = rs.GetExecutionInfo();
				_diagInfo.ExecutionDateTime = execInfo.ExecutionDateTime;
			}
			catch (SoapException e)
			{
				return Result.Fail<ReportRenderInfo>(e.ToString());
			}

			try
			{
				var stream = new MemoryStream();
				stream.Write(result, 0, result.Length);
				stream.Position = 0;

				return Result.Ok(ReportRenderInfo.Create(stream, _diagInfo));
			}
			catch (Exception e)
			{
				return Result.Fail<ReportRenderInfo>(e.ToString());
			}
		}

		public static ReportWrapper Create(ServerConnection connection, string reportPath)
		{
			return new ReportWrapper(connection, reportPath);
		}
	}
}
