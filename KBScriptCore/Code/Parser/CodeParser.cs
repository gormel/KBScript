using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using KBScriptCore.Code.CodeObjects;

namespace KBScriptCore.Code.Parser
{
	internal class CodeParser : OperationParser<Operation>
	{
		private List<Type> mTypes;

		private IEnumerable<IOperationParcer> mParsers
		{
			get 
			{
				return mTypes.Select(type => (IOperationParcer) Activator.CreateInstance(type));
			}
		}

		public static readonly CodeParser Instance = new CodeParser();

		private CodeParser()
		{
			InitOperationInstances();
		}

		private void InitOperationInstances()
		{
			mTypes =   (from a in AppDomain.CurrentDomain.GetAssemblies()
						from t in a.GetTypes()
						where typeof (IOperationParcer).IsAssignableFrom(t)
						where t.GetConstructors(BindingFlags.Public | BindingFlags.Instance).Length > 0
						select t).ToList();
		}

		public override Operation Parse(string code)
		{
			Moved = 0;
			var parsed =   (from p in mParsers
							let result = p.Parse(code)
							let moved = p.Moved
							where result != null
							select new { result, moved }).ToList();

			if (parsed.Count != 1)
				return null;

			Moved = parsed[0].moved;
			return parsed[0].result;
		}
	}
}
