using NUnit.Framework;
using GrafGenerator.ReportMetrics.ReportingServices.Connection;
using GrafGenerator.ReportMetrics.Tests.Config;

namespace GrafGenerator.ReportMetrics.Tests
{
	[TestFixture]
	public class ServerConnectionFixture
	{
		private string _serverPath;


		[SetUp]
		public void SetUp()
		{
			var config = new Extractor("config.json").Config;

			_serverPath = config.ServerPath;
		}

		[Test]
		public void Test_ReportingService_ConnectionExist()
		{
			var connection = ServerConnection.Create(_serverPath, true); // assume connection to localhost
			Assert.That(connection.ReportingService, Is.Not.Null);

			var extensionsList = connection.ReportingService.ListExtensions("All");
			Assert.That(extensionsList.Length, Is.GreaterThan(0));
		}

        [Test]
		public void Test_ReportExecutionService_ConnectionExist()
		{
			var connection = ServerConnection.Create(_serverPath, true); // assume connection to localhost
			Assert.That(connection.ReportingService, Is.Not.Null);

			var extensionsList = connection.ExecutionService.ListRenderingExtensions();
			Assert.That(extensionsList.Length, Is.GreaterThan(0));
		}
	}
}
