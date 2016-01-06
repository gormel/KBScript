using System.Collections.Generic;
using System.Windows.Forms;
using Injection.Attributes;
using Injection.Main;
using KBScriptCore.Code;
using KBScriptCore.Code.CodeObjects;
using KBScriptEditor.Managment;
using KBScriptEditor.Panels;
using KBScriptEditor.Script;
using WeifenLuo.WinFormsUI.Docking;

namespace KBScriptEditor
{
	public partial class MainForm : Form
	{
		private readonly CodeManager mCodeManager = new CodeManager();
		private readonly ScriptListPanel mScriptList = new ScriptListPanel();
		private readonly LogPanel mLogPanel = new LogPanel();

		private CodePanel mSelectedPanel;

		[Inject]
		private ScriptEventManager mManager;

		public MainForm()
		{
			InjectionManager.Connect(this);
			InitializeComponent();
		}

		private void MainForm_Load(object sender, System.EventArgs e)
		{
			mCodeManager.OnLog += mCodeManager_OnLog;
			mManager.ScriptSelected += scriptList_ScriptSelected;
			mScriptList.Show(mainDock, DockState.DockLeft);

			mLogPanel.Show(mainDock, DockState.DockBottomAutoHide);
		}

		void mCodeManager_OnLog(object sender, string e)
		{
			mLogPanel.Log(e);
		}

		void scriptList_ScriptSelected(object sender, ScriptItem e)
		{
			var panel = new CodePanel(e);
			panel.GotFocus += panel_GotFocus;
			panel.Show(mainDock, DockState.Document);
		}

		void panel_GotFocus(object sender, System.EventArgs e)
		{
			mSelectedPanel = (CodePanel)sender;
		}

		private void StartButton_Click(object sender, System.EventArgs e)
		{
			if (mSelectedPanel == null)
				return;

			mCodeManager.Code = mSelectedPanel.Script.Text;
			mCodeManager.Execute();
		}
	}
}
