using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KBScriptCore.Code.CodeObjects;

namespace KBScriptCore.Code.Parser
{
	public class WaitParser : KeywordParser<WaitOperation>
	{
		public WaitParser() : base("wait")
		{
		}
	}
}
