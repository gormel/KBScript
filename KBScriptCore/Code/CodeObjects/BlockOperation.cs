using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KBScriptCore.Code.CodeObjects;

namespace KBScriptCore.Code
{
	internal class BlockOperation : Operation
	{
		public BlockOperation()
		{
			Operations = new List<Operation>();
		}
		public List<Operation> Operations { get; private set; } 

		public override void Execute()
		{
			foreach (var operation in Operations)
			{
				operation.Execute();
			}
		}

		public override string ToString()
		{
			return "{" + Operations.Select(o => o.ToString()).Aggregate((a, b) => a + ";" + b) + "}";
		}
	}
}
