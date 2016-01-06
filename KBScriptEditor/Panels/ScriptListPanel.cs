using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Injection.Attributes;
using Injection.Main;
using KBScriptEditor.Managment;
using KBScriptEditor.Script;
using WeifenLuo.WinFormsUI.Docking;

namespace KBScriptEditor.Panels
{
	public partial class ScriptListPanel : DockContent
	{
		[Inject]
		private ScriptEventManager mManager;

		public ScriptListPanel()
		{
			InjectionManager.Connect(this);
			InitializeComponent();
			InitUserComponents();
		}

		private void InitUserComponents()
		{
			listView1.ContextMenu = new ContextMenu();
			var addItem = new MenuItem("Add script");
			addItem.Click += addItem_Click;
			listView1.ContextMenu.MenuItems.Add(addItem);

			var removeItem = new MenuItem("Remove script");
			removeItem.Click += removeItem_Click;
			listView1.ContextMenu.MenuItems.Add(removeItem);

			var renameItem = new MenuItem("Rename script");
			renameItem.Click += RenameItemOnClick;
			listView1.ContextMenu.MenuItems.Add(renameItem);
		}

		private void RenameItemOnClick(object sender, EventArgs eventArgs)
		{
			if (listView1.SelectedItems.Count <= 0)
				return;

			listView1.SelectedItems[0].BeginEdit();
		}

		void removeItem_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
				return;

			var script = (ScriptItem)listView1.SelectedItems[0].Tag;
			listView1.SelectedItems[0].Remove();
			mManager.CallScriptRemoved(script);
		}

		void addItem_Click(object sender, EventArgs e)
		{
			var count = listView1.Items.Cast<ListViewItem>().Select(i => i.Text.StartsWith("New Script")).Count();
			var name = "New Script" + (count > 0 ? count.ToString() : "");

			var script = new ScriptItem {Name = name};

			AddScript(script);
		}

		public void AddScript(ScriptItem item)
		{
			var listItem = new ListViewItem(item.Name) { Text = item.Name, Tag = item };

			listView1.Items.Add(listItem);
			mManager.CallScriptSelected(item);

			listItem.BeginEdit();
		}

		private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			var selected = listView1.GetItemAt(e.X, e.Y);
			if (selected == null)
				return;

			mManager.CallScriptSelected((ScriptItem) selected.Tag);
		}

		private void listView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
		{
			var script = (ScriptItem)listView1.Items[e.Item].Tag;
			script.Name = e.Label;

			mManager.CallSCriptChanged(script);
		}
	}
}
