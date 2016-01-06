using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBScriptCore.Code.CodeObjects
{
	public class RepeatOperation : Operation
	{
		public int RepeatCount { get; set; }

		public List<Operation> Operations { get; private set; }

		public RepeatOperation()
		{
			Operations = new List<Operation>();
		}

		public override void Execute()
		{
			for (int i = 0; i < RepeatCount; i++)
			{
				foreach (var operation in Operations)
				{
					operation.Execute();
				}
			}
		}

		public override string ToString()
		{
			return "repeat (" + RepeatCount + ") {" + Operations.Select(o => o.ToString()).Aggregate((a, b) => a + "; " + b) + "}";
		}
	}
}
