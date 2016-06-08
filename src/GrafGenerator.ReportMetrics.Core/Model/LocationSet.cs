using System.Collections.Generic;
using System.Linq;

namespace GrafGenerator.ReportMetrics.Core.Model
{
	public class LocationSet
	{
		private readonly Dictionary<string, Location> _locations;


		private LocationSet(Dictionary<string, Location> locations)
		{
			_locations = locations;
		}

		public LocationSet New(string name, Location location)
		{
			if (_locations.ContainsKey(name))
				_locations[name] = location;
			else
				_locations.Add(name, location);

			return new LocationSet(_locations);
		}


		public Location this[string key] => _locations[key];


		public static LocationSet Create()
		{
			return new LocationSet(null);
		}
	}
}
