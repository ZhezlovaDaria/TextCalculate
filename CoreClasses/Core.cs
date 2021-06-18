using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreClasses
{

	public interface IOperator
	{
		string Name { get; }
		int Priority { get; }
		int NArgs { get; }
		IExpression Make(IExpression[] args);
	}

	public interface IValue
    {
        string ToString();
    }

	public interface IExpression
	{
		Lexem Lexem { get; set; }
		IValue GetValue();
		void StartExp(IExpression[] expression);
	}

}
