using KBScriptCore.Code.CodeObjects;

namespace KBScriptCore.Code.Parser
{
	public class RepeatParser : OperationParser<RepeatOperation>
	{
		private const string KeyWord = "repeat";

		public override RepeatOperation Parse(string code)
		{
			RepeatOperation result = new RepeatOperation();

			SkipSpaces(code);

			if (!code.Substring(Moved).StartsWith(KeyWord))
				return null;
			Moved += KeyWord.Length;

			SkipSpaces(code);

			if (code[Moved] != '(')
				return null;
			Moved++;

			SkipSpaces(code);

			var begin = Moved;

			while (char.IsDigit(code[Moved]))
				Moved++;

			var len = Moved - begin;

			var count = int.Parse(code.Substring(begin, len));

			result.RepeatCount = count;

			SkipSpaces(code);

			if (code[Moved] != ')')
				return null;
			Moved++;

			var blockParser = new BlockParser();
			var blockOperation = blockParser.Parse(code.Substring(Moved));

			if (blockOperation == null)
				return null;

			Moved += blockParser.Moved;

			result.Operations.AddRange(blockOperation.Operations);

			return result;
		}
	}
}
