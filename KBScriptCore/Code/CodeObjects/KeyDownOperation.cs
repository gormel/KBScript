using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KBScriptCore.Input;

namespace KBScriptCore.Code.CodeObjects
{
	public class KeyDownOperation : KeywordOperation
	{
		public Keys KeyCode
		{
			get { return (Keys) Enum.Parse(typeof (Keys), Parameters[0]); }
		}
		public override void Execute()
		{
			InputOperations.KeyDown(this.KeyCode);
		}

		public override string ToString()
		{
			return "kdown[" + Parameters[0] + "]";
		}
	}
}
