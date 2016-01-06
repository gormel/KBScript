using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using KBScriptCore.Code.CodeObjects;

namespace KBScriptCore.Code.Parser
{
	public interface IOperationParcer
	{
		Operation Parse(string code);
		int Moved { get; }
	}

	public abstract class OperationParser<T> : IOperationParcer where T : Operation
	{
		public abstract T Parse(string code);

		public int Moved { get; protected set; }

		Operation IOperationParcer.Parse(string code)
		{
			return Parse(code);
		}

		protected void SkipSpaces(string code)
		{
			while (char.IsWhiteSpace(code[Moved]))
				Moved++;
		}
	}
}
