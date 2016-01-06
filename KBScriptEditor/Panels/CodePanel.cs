using System;
using Injection.Attributes;
using Injection.Main;
using KBScriptEditor.Managment;
using KBScriptEditor.Script;
using WeifenLuo.WinFormsUI.Docking;

namespace KBScriptEditor.Panels
{
	public partial class CodePanel : DockContent
	{
		public ScriptItem Script { get; private set; }

		[Inject]
		private ScriptEventManager mManager;

		public CodePanel(ScriptItem item)
		{
			InjectionManager.Connect(this);
			mManager.ScriptRemoved += mManager_ScriptRemoved;
			mManager.ScriptChanged += mManager_ScriptChanged;
			Script = item;
			InitializeComponent();
		}

		void mManager_ScriptChanged(object sender, ScriptItem e)
		{
			if (e == Script)
			{
				Text = e.Name;
				if (textBox1.Text != e.Text)
					textBox1.Text = e.Text;
			}
		}

		void mManager_ScriptRemoved(object sender, ScriptItem e)
		{
			if (e == Script)
				Close();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			Script.Text = textBox1.Text;
			mManager.CallSCriptChanged(Script);
		}

		private void CodePanel_Load(object sender, EventArgs e)
		{
			Text = Script.Name;
		}
	}
}
