using System.Diagnostics;
using GrafGenerator.ReportMetrics.ReportingServices.Auxiliary;
using GrafGenerator.ReportMetrics.ReportingServices.Connection;
using GrafGenerator.ReportMetrics.ReportingServices.ReportAccessWrappers;
using GrafGenerator.ReportMetrics.Tests.Config;
using NUnit.Framework;
using ReportMetrics.Core.Model;

namespace GrafGenerator.ReportMetrics.Tests
{
	[TestFixture]
	public class ReportWrapperFixture
	{
		private string _serverPath;
		private string _reportPath;

		[SetUp]
		public void SetUp()
		{
			var config = new Extractor("config.json").Config;

			_serverPath = config.ServerPath;
			_reportPath = config.ReportPath;
		}

		[Test]
		public void SimpleTest()
		{
			var connection = ServerConnection.Create(_serverPath, true);
			var reportWrapper = ReportWrapper.Create(connection, _reportPath);

			var parameters = ParamPack.Create();

			var result = reportWrapper.Render(ReportRenderFormat.Formularizer, parameters.Pack());

			if (result.Failure)
				Debug.WriteLine(result.Error);

			Assert.That(result.Success, Is.True);

			Assert.That(result.Value.Stream, Is.Not.Null);
			Assert.That(result.Value.Stream.Length, Is.GreaterThan(0));
		}
	}
}
