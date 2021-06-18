using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreClasses;

namespace Degree
{
	public class Degree : IOperator
	{
		public string Name { get { return "^"; } }

		public int Priority { get { return 70; } }

		public int NArgs { get { return 2; } }

		public IExpression Make(IExpression[] args)
		{
			DegreeExpression dge = new DegreeExpression();
			dge.StartExp(args);
			return dge;
		}
	}
}
