using System;
using System.Threading.Tasks;
using KBScriptCore.Code.CodeObjects;
using KBScriptCore.Code.Parser;

namespace KBScriptCore.Code
{
	public class CodeManager
	{
		public event EventHandler<string> OnLog; 

		public string Code { get; set; }

		public void Execute()
		{
			var task = Task.Run(() =>
			{
				Operation body = new EmptyOperation();
				if (!string.IsNullOrEmpty(Code))
				{
					Log("Building....");
					body = CodeParser.Instance.Parse(Code);
					Log("Building complete: " + (body == null ? "Error" : "Success"));
				}
				if (body != null)
					body.Execute();
			});
		}

		private void Log(string text)
		{
			if (OnLog != null)
				OnLog(this, text);
		}
	}
}
