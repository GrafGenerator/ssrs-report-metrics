using System;
using System.IO;

namespace GrafGenerator.ReportMetrics.Tests.Config
{
	internal static class ConfigPathResolver
	{
		public static string GetConfig(string name)
		{
			var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, name);

			if (!File.Exists(path))
				throw new FileNotFoundException();

			return path;
		}
	}
}