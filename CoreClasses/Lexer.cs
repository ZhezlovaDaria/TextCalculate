using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoreClasses
{
	[Serializable]
	public struct Lexem
	{
		public enum Type { Number, Operator, Variable, OpenParenthesis, CloseParenthesis, Space };
		public Type T;
		public int Start;
		public int Length;
		public string Content;

		public Lexem(Type t, int start, int legth, string content)
		{
			T = t;
			Start = start;
			Length = legth;
			Content = content;
		}
	}
	public class Lexer
	{
		static Dictionary<Lexem.Type, Regex> Patterns = new Dictionary<Lexem.Type, Regex>
		{
			{ Lexem.Type.Space, new Regex(@"^\s+") },
			{ Lexem.Type.Number, new Regex(@"^\d+(\.\d+)?") }, //"^\d+(?:[.,]\d+)"
			{ Lexem.Type.OpenParenthesis, new Regex(@"^\(") },
			{ Lexem.Type.CloseParenthesis, new Regex(@"^\)") },
		};
		static Regex VarPattern = new Regex(@"[a-z][a-z0-9]*", RegexOptions.IgnoreCase);
		public IEnumerable<Lexem> Split(string data, IReadOnlyList<string> ops)
		{
			int index = 0;
			while (index < data.Length)
			{
				bool found = false;
				foreach (var kv in Patterns)
				{
					string s = data.Substring(index);
					var match = kv.Value.Match(s);//var match = kv.Value.Match(data, index);
					if (match.Success && kv.Key != Lexem.Type.Space)
					{
						found = true;
						yield return new Lexem(kv.Key, index, match.Length, match.Value);
						index += match.Length;
						break;
					}
				}
				if (!found)
				{
					foreach (string op in ops)
						if (data.Substring(index, op.Length) == op)
						{
							found = true;
							yield return new Lexem(Lexem.Type.Operator, index, op.Length, op);
							index += op.Length;
							break;
						}
				}
				if (!found)
				{
					var match = VarPattern.Match(data, index);
					if (match.Success)
					{
						found = true;
						yield return new Lexem(Lexem.Type.Variable, index, match.Length, match.Value);
						index += match.Length;
					}
				}
				if (!found)
				{
					throw new ParseException("Ошибка", index, 1);
				}
			}
		}
	}
}
