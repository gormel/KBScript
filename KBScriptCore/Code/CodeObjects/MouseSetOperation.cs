using KBScriptCore.Input;

namespace KBScriptCore.Code.CodeObjects
{
	public class MouseSetOperation : KeywordOperation
	{
		public int X
		{
			get { return int.Parse(Parameters[0]); }
		}

		public int Y
		{
			get { return int.Parse(Parameters[1]); }
		}

		public override void Execute()
		{
			InputOperations.SetCursorPosition(X, Y);
		}

		public override string ToString()
		{
			return "mset[" + Parameters[0] + ", " + Parameters[1] + "]";
		}
	}
}
