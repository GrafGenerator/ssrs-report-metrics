using System.IO;
using Newtonsoft.Json.Linq;

namespace GrafGenerator.ReportMetrics.Tests.Config
{
	class Extractor
	{
		public dynamic Config { get; }

		public Extractor(string configName)
		{
			var configPath = ConfigPathResolver.GetConfig(configName);
			var content = File.ReadAllText(configPath);
			dynamic config = JObject.Parse(content);

			Config = config;
		}
	}
}
