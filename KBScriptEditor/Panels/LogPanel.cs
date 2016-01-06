using System;
using WeifenLuo.WinFormsUI.Docking;

namespace KBScriptEditor.Panels
{
	public partial class LogPanel : DockContent
	{
		public LogPanel()
		{
			InitializeComponent();
		}

		public void Log(string text)
		{
			if (textBox1.InvokeRequired)
			{
				textBox1.Invoke(new Action<string>(Log), text);
			}
			else
			{
				textBox1.Text += "[" + DateTime.Now.ToString("T") + "]: " + text + Environment.NewLine;
			}
		}
	}
}
