using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBScriptCore.Code.CodeObjects
{
	public abstract class KeywordOperation : Operation
	{
		protected string KeyWord { get; set; }
		public List<string> Parameters { get; private set; }

		protected KeywordOperation()
		{
			Parameters = new List<string>();
		}
	}
}
