using System.Threading;

namespace KBScriptCore.Code.CodeObjects
{
	public class WaitOperation : KeywordOperation
	{
		public int WaitTime
		{
			get { return int.Parse(Parameters[0]); }
		}
		public override void Execute()
		{
			Thread.Sleep(WaitTime);
		}

		public override string ToString()
		{
			return "wait[" + Parameters[0] + "]";
		}
	}
}
