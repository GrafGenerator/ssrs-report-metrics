using NUnit.Framework;
using GrafGenerator.ReportMetrics.ReportingServices.Connection;

namespace GrafGenerator.ReportMetrics.Tests
{
	[TestFixture]
	public class ServerConnectionFixture
	{
        [Test]
		public void Test_ReportingService_ConnectionExist()
		{
			var connection = ServerConnection.Create("http://uk-sql01/ReportServer", true); // assume connection to localhost
			Assert.That(connection.ReportingService, Is.Not.Null);

			var extensionsList = connection.ReportingService.ListExtensions("All");
			Assert.That(extensionsList.Length, Is.GreaterThan(0));
		}

        [Test]
		public void Test_ReportExecutionService_ConnectionExist()
		{
			var connection = ServerConnection.Create("http://uk-sql01/ReportServer", true); // assume connection to localhost
			Assert.That(connection.ReportingService, Is.Not.Null);

			var extensionsList = connection.ExecutionService.ListRenderingExtensions();
			Assert.That(extensionsList.Length, Is.GreaterThan(0));
		}
	}
}
