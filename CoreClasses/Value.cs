using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreClasses
{
	[Serializable]
	public class DoubleValue : IValue
	{
		public double value;
		public DoubleValue(double v) { value = v; }
		public override string ToString()
		{
			return value.ToString();
		}
	}
	[Serializable]
	public class TupleValue : IValue
	{
		public IValue[] items;
		public TupleValue(IValue arg1, IValue arg2)
		{
			items = new IValue[] { arg1, arg2 };
		}
		public TupleValue(TupleValue prefix, IValue suffix)
		{
			items = new IValue[prefix.items.Length + 1];
			for (int i = 0; i < prefix.items.Length; i++)
				items[i] = prefix.items[i];
			items[items.Length - 1] = suffix;
		}
	}
	[Serializable]
	public class ConstExpression : IExpression
	{
		public Lexem Lexem { get; set; }
		private IValue Value;
		public IValue GetValue() { return Value; }
		public ConstExpression(IValue v) { Value = v; }
		public void StartExp(IExpression[] expression) { Value = ((IValue)expression[0]); }
	}
}
