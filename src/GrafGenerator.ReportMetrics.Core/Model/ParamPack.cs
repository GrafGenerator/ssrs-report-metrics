using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GrafGenerator.ReportMetrics.Core.Model
{
	public class ParamPack
	{
		public string Name { get; }
		private readonly Dictionary<string, string> _parameters;

		private ParamPack(string name)
		{
			Name = name;
			_parameters = new Dictionary<string, string>();
		}

		private ParamPack(string name, Dictionary<string, string> parameters)
		{
			Name = name;
			_parameters = parameters.ToDictionary(kv => kv.Key, kv => kv.Value);
		}


		public ParamPack Add(string name, string value)
		{
			if (_parameters.ContainsKey(name))
				_parameters[name] = value;
			else
				_parameters.Add(name, value);

			return this;
		}



		private void MergeInternal(Dictionary<string, string> parameters)
		{
			foreach (var p in parameters)
			{
				if (_parameters.ContainsKey(p.Key))
					_parameters[p.Key] = p.Value;
				else
					_parameters.Add(p.Key, p.Value);
			}
		}

		public ParamPack Merge(ParamPack other)
		{
			var pack = new ParamPack(Name, _parameters);
			pack.MergeInternal(other._parameters);

			return pack;
		}



		public ParameterValue[] Pack()
		{
			return _parameters
				.Select(kv => new ParameterValue {Name = kv.Key, Value = kv.Value})
				.ToArray();
		}

		public ParameterValue[] Pack(IEnumerable<string> names)
		{
			return _parameters
				.Where(kv => Name.Contains(kv.Key))
				.Select(kv => new ParameterValue { Name = kv.Key, Value = kv.Value })
				.ToArray();
		}



		public static ParamPack Create(string name)
		{
			return new ParamPack(name);
		}
	}
}