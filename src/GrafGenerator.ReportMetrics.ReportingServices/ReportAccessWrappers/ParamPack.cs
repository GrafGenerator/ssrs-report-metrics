using System.Collections.Generic;

namespace GrafGenerator.ReportMetrics.ReportingServices.ReportAccessWrappers
{
	public class ParamPack
	{
		private readonly List<ParameterValue> _parameters;

		private ParamPack()
		{
			_parameters = new List<ParameterValue>();
		}


		public ParamPack Add(string name, string value)
		{
			_parameters.Add(new ParameterValue
			{
				Name = name,
				Value = value
			});

			return this;
		}

		public ParameterValue[] Pack()
		{
			return _parameters.ToArray();
		}


		public ParamPack Create()
		{
			return new ParamPack();
		}
	}
}