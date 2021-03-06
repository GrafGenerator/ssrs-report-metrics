﻿using System.Collections.Generic;
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

		public ParamSet New(string name, ParamPack pack)
		{
			if (_packs.ContainsKey(name))
				_packs[name] = pack;
			else
				_packs.Add(name, pack);

			return new ParamSet(_packs);
		}


		public ParamPack this[string key] => _packs[key];


		public ParamPack Merge(IEnumerable<string> names)
		{
			var filteredPacks =
				from name in names
				select _packs[name];

			return filteredPacks
				.Aggregate(ParamPack.Create(""), (aggr, cur) => aggr.Merge(cur));
		}


		public static ParamSet Create()
		{
			return new ParamSet(null);
		}
	}
}
