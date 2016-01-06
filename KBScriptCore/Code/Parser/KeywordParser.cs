using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KBScriptCore.Code.CodeObjects;

namespace KBScriptCore.Code.Parser
{
	public abstract class KeywordParser<T> : OperationParser<T> where T : KeywordOperation, new ()
	{
		private readonly string KeyWord;
		protected KeywordParser(string keyWord)
		{
			KeyWord = keyWord;
		}

		public override T Parse(string code)
		{
			T result = new T();
			Moved = 0;
			SkipSpaces(code);

			if (!code.Substring(Moved).StartsWith(KeyWord))
				return null;
			Moved += KeyWord.Length;

			SkipSpaces(code);

			if (code[Moved++] != '[')
				return null;

			result.Parameters.AddRange(ParseParameters(code));

			if (code[Moved] != ']')
				return null;
			Moved++;

			return result;
		}

		private List<string> ParseParameters(string code)
		{
			List<string> result = new List<string>(); 
			
			SkipSpaces(code);

			var start = Moved;

			while (char.IsLetter(code[Moved]) || char.IsDigit(code[Moved]))
				Moved++;

			var len = Moved - start;

			var arg = code.Substring(start, len);

			result.Add(arg);

			SkipSpaces(code);

			if (code[Moved] != ',')
				return result;
			Moved++;

			result.AddRange(ParseParameters(code));

			return result;
		}
	}
}
