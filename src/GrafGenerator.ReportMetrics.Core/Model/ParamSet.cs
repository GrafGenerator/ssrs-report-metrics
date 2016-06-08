using System.Collections.Generic;
using System.Linq;

namespace GrafGenerator.ReportMetrics.Core.Model
{
	public class ParamSet
	{
		public string Name { get; }
		private readonly Dictionary<string, string> _parameters = new Dictionary<string, string>();


		private ParamSet(string name, ParamPack parameters)
		{
			Name = name;
			MergeInternal(parameters);
		}

		private void MergeInternal(ParamPack parameters)
		{
			var other = parameters.ToDictionary(p => p.Key, p => p.Value);

			foreach (var p in other)
			{
				if (_parameters.ContainsKey(p.Key))
					_parameters[p.Key] = p.Value;
				else
					_parameters.Add(p.Key, p.Value);
			}
		}


		public ParamSet Merge(ParamPack parameters)
		{
			var newSet = new ParamSet(Name, ParamPack.Create(_parameters));
			newSet.MergeInternal(parameters);

			return newSet;
		}


		public static ParamSet Create(string name, ParamPack parameters)
		{
			return new ParamSet(name, parameters);
		}
	}
}
