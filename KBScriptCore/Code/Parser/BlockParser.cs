using System.Collections.Generic;
using KBScriptCore.Code.CodeObjects;

namespace KBScriptCore.Code.Parser
{
	internal class BlockParser : OperationParser<BlockOperation>
	{
		public override BlockOperation Parse(string code)
		{
			BlockOperation result = new BlockOperation();
			base.Moved = 0;
			SkipSpaces(code);

			if (code[Moved++] != '{')
				return null;

			result.Operations.AddRange(ParseBody(code));

			if (code[Moved] != '}')
				return null;
			Moved++;

			return result;
		}

		private List<Operation> ParseBody(string code)
		{
			List<Operation> result = new List<Operation>(); 
			
			SkipSpaces(code);
			
			var operation = CodeParser.Instance.Parse(code.Substring(Moved));
			Moved += CodeParser.Instance.Moved;

			if (operation == null)
				result.Add(new EmptyOperation());
			else
				result.Add(operation);

			SkipSpaces(code);

			if (code[Moved] != ';')
				return result;
			Moved++;

			result.AddRange(ParseBody(code));
			return result;
		}
	}
}
