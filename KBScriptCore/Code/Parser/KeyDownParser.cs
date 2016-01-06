using System;
using System.Windows.Forms;
using KBScriptCore.Code.CodeObjects;

namespace KBScriptCore.Code.Parser
{
	public class KeyDownParser : KeywordParser<KeyDownOperation>
	{
		public KeyDownParser()
			: base("kdown")
		{
		}
	}
}
