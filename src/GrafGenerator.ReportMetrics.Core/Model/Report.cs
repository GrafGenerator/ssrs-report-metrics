namespace GrafGenerator.ReportMetrics.Core.Model
{
	public class Report
	{
		public TestCase TestCase { get; }

		public Location Location { get; set; }
		public ParamPack Parameters { get; set; }


		private Report()
		{
		}

		private Report(Report other)
		{
			Location = other.Location;
			Parameters = other.Parameters;
			TestCase = other.TestCase;
		}

		private Report(Report other, TestCase testCase)
			:this(other)
		{
			TestCase = testCase;
		}

		public Report Bind(TestCase testCase)
		{
			return new Report(this, testCase);
		}



		public static Report Create()
		{
			return new Report();
		}
	}
}
