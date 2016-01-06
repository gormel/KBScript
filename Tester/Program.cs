using KBScriptCore.Code;

namespace Tester
{
	class Program
	{
		static void Main(string[] args)
		{
			var codeManager = new CodeManager();
			codeManager.Code = "  {  {  kdown  [      A ] ; repeat   (   6 ) {    kdown[S]; kdown[R]   } }  ; {    }   }    ";

			int a = 7;
		}
	}
}
