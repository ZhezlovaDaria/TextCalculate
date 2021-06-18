using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreClasses
{
	public class Multiplication : IOperator
	{
		public string Name { get { return "*"; } }

		public int Priority { get { return 50; } }

		public int NArgs { get { return 2; } }

		public IExpression Make(IExpression[] args)
		{
			MultiplicationExpression me = new MultiplicationExpression();
			me.StartExp(args);
			return me;
		}
	}

	public class MultiplicationExpression : IExpression
	{
		private IExpression arg1;
		private IExpression arg2;
		public Lexem Lexem { get; set; }

		public void StartExp(IExpression[] expression)
		{
			arg1 = expression[0];
			arg2 = expression[1];
		}

		public IValue GetValue()
		{
			IValue v1 = arg1.GetValue();
			IValue v2 = arg2.GetValue();
			double num1 = ((DoubleValue)v1).value;
			double num2 = ((DoubleValue)v2).value;
			return new DoubleValue(num1 * num2);
		}
	}
}
