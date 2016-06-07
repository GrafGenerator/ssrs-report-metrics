using GrafGenerator.ReportMetrics.ReportingServices.Clients;

namespace GrafGenerator.ReportMetrics.ReportingServices.Connection
{
	public class ServerConnection
	{
		public string ReportingServiceUrl { get; private set; }
		public string ExecutionServiceUrl { get; private set; }

		public bool UseDefaultCredentials { get; private set; }



		public ReportingService2010 ReportingService { get; private set; }
		public ReportExecutionService ExecutionService { get; private set; }



		private ServerConnection(string server, bool useDefaultCredentials)
		{
			var fixedServerUrl = server.TrimEnd('/');
			var reportSvcUrl = fixedServerUrl + "/reportservice2010.asmx";
			var reportExecUrl = fixedServerUrl + "/reportexecution2005.asmx";

			ReportingServiceUrl = reportSvcUrl;
			ExecutionServiceUrl = reportExecUrl;
			UseDefaultCredentials = useDefaultCredentials;

			ReportingService = new ReportingService2010
			{
				Url = reportSvcUrl,
				UseDefaultCredentials = useDefaultCredentials
			};

			ExecutionService = new ReportExecutionService()
			{
				Url = reportExecUrl,
				UseDefaultCredentials = useDefaultCredentials
			};
		}

		public static ServerConnection Create(string url, bool useDefaultCredentials)
		{
			return new ServerConnection(url, useDefaultCredentials);
		}

		public static ServerConnection Default => Create("http://localhost/ReportServer", true);
	}
}
