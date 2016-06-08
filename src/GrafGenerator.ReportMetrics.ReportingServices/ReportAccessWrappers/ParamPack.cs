using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GrafGenerator.ReportMetrics.ReportingServices.ReportAccessWrappers
{
	public class ParamPack: IEnumerable<KeyValuePair<string, string>>
	{
		private readonly Dictionary<string, string> _parameters;

		private ParamPack()
		{
			_parameters = new Dictionary<string, string>();
		}

		private ParamPack(Dictionary<string, string> parameters)
		{
			_parameters = parameters;
		}




		public ParamPack Add(string name, string value)
		{
			if (_parameters.ContainsKey(name))
				_parameters[name] = value;
			else
				_parameters.Add(name, value);

			return this;
		}

		public ParameterValue[] Pack()
		{
			return _parameters.Select(kv => new ParameterValue {Name = kv.Key, Value = kv.Value}).ToArray();
		}


		public static ParamPack Create()
		{
			return new ParamPack();
		}

		public static ParamPack Create(Dictionary<string, string> parameters)
		{
			return new ParamPack(parameters);
		}

		public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
		{
			return _parameters.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}