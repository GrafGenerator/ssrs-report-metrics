namespace GrafGenerator.ReportMetrics.Core.Model
{
	public class Location
	{
		public string Server { get; private set; }
		public string Folder { get; private set; }
		public string Name { get; private set; }

		private Location(string name, string server, string folder)
		{
			Name = name;
			Server = server;
			Folder = folder;
		}


		public Location Create(string name, string server, string folder)
		{
			return new Location(name, server, folder);
		}
	}
}
