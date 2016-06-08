using System.Diagnostics;
using System.Web.Services.Protocols;
using GrafGenerator.ReportMetrics.Core.Model;
using GrafGenerator.ReportMetrics.ReportingServices.Auxiliary;
using GrafGenerator.ReportMetrics.ReportingServices.Connection;
using GrafGenerator.ReportMetrics.ReportingServices.ReportAccessWrappers;
using GrafGenerator.ReportMetrics.Tests.Config;
using NUnit.Framework;

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

		[TestCase(ReportRenderFormat.Formularizer)]
		[TestCase(ReportRenderFormat.Excel)]
		[TestCase(ReportRenderFormat.Html)]
		[TestCase(ReportRenderFormat.Pdf)]
		public void SmokeTest_AllFormats(ReportRenderFormat format)
		{
			var connection = ServerConnection.Create(_serverPath, true);
			var reportWrapper = ReportWrapper.Create(connection, _reportPath);

			var parameters = ParamPack.Create();

			var result = reportWrapper.Render(format, parameters.Pack());

			if (result.Failure)
				Debug.WriteLine(result.Error);

			Assert.That(result.Success, Is.True);

			Assert.That(result.Value.Stream, Is.Not.Null);
			Assert.That(result.Value.Stream.Length, Is.GreaterThan(0));
		}

		[Test]
		public void SmokeTest_UnknownFails()
		{
			var connection = ServerConnection.Create(_serverPath, true);
			var reportWrapper = ReportWrapper.Create(connection, _reportPath);

			var parameters = ParamPack.Create();

			var result = reportWrapper.Render(ReportRenderFormat.Unknown, parameters.Pack());

			Assert.That(result.Failure, Is.True);
		}
	}
}
