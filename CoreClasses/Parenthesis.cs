using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreClasses
{
	public class Open : IOperator
	{
		public string Name { get { return "("; } }

		public int Priority { get { return -1; } }

		public int NArgs { get { return 0; } }

		public IExpression Make(IExpression[] args)
		{
			return null;
		}
	}

	public class Close : IOperator
	{
		public string Name { get { return ")"; } }

		public int Priority { get { return -1; } }

		public int NArgs { get { return 0; } }

		public IExpression Make(IExpression[] args)
		{
			return null;
		}
	}
}
