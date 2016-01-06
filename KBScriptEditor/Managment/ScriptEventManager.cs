using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Injection.Attributes;
using KBScriptEditor.Script;

namespace KBScriptEditor.Managment
{
	[Singletone]
	public class ScriptEventManager
	{
		public event EventHandler<ScriptItem> ScriptCreated;
		public event EventHandler<ScriptItem> ScriptChanged;
		public event EventHandler<ScriptItem> ScriptRemoved;
		public event EventHandler<ScriptItem> ScriptSelected;

		public void CallScriptCreated(ScriptItem item)
		{
			if (ScriptCreated != null)
				ScriptCreated(this, item);
		}

		public void CallSCriptChanged(ScriptItem item)
		{
			if (ScriptChanged != null)
				ScriptChanged(this, item);
		}

		public void CallScriptRemoved(ScriptItem item)
		{
			if (ScriptRemoved != null)
				ScriptRemoved(this, item);
		}

		public void CallScriptSelected(ScriptItem item)
		{
			if (ScriptSelected != null)
				ScriptSelected(this, item);
		}
	}
}
