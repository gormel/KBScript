using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KBScriptCore.Code.CodeObjects;

namespace KBScriptCore.Code.Parser
{
	public class MouseSetParser : KeywordParser<MouseSetOperation>
	{
		public MouseSetParser() : base("mset")
		{
		}
	}
}
