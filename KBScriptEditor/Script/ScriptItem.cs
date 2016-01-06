using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBScriptEditor.Script
{
	public class ScriptItem
	{
		public string Name { get; set; }
		public string Text { get; set; }

		public ScriptItem()
		{
			Name = "";
			Text = "";
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
