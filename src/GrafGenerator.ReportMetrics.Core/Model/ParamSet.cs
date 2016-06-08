using System.Collections.Generic;
using System.Linq;

namespace GrafGenerator.ReportMetrics.Core.Model
{
	public class ParamSet
	{
		private readonly Dictionary<string, ParamPack> _packs;


		private ParamSet(Dictionary<string, ParamPack> packs)
		{
			_packs = packs;
		}

		public ParamSet New(string name, ParamPack location)
		{
			if (_packs.ContainsKey(name))
				_packs[name] = location;
			else
				_packs.Add(name, location);

			return new ParamSet(_packs);
		}


		public ParamPack this[string key] => _packs[key];


		public ParamPack Merge(IEnumerable<string> names)
		{
			return _packs
				.Where(kv => names.Contains(kv.Key))
				.Aggregate(ParamPack.Create(""), (aggr, cur) => aggr.Merge(cur.Value));
		}


		public static ParamSet Create()
		{
			return new ParamSet(null);
		}
	}
}
