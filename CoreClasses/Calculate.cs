using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreClasses
{
	public class Calculate
	{
		Stack<IValue> Number = new Stack<IValue>();
		Stack<IOperator> Operation = new Stack<IOperator>();
		List<Lexem> l;

		public void StackExp(Model m)
		{
			l = m.syntax_tree;
			for (int i = 0; i < l.Count; i++)
			{
				switch (l[i].T) {
					case (Lexem.Type.Number):
						Number.Push(new DoubleValue(Double.Parse(l[i].Content)));
						break;
					case (Lexem.Type.Operator):
						if (Operation.Count != 0)
						{
							foreach (IOperator o in Op_List.op_list)
							{
								if (l[i].Content == o.Name)
								{
									while (Operation.Count>0&&o.Priority < Operation.Peek().Priority && Operation.Peek().Name != "(")
									{
										ExpSingle();
									}
									Operation.Push(o);
								}
							}
						}
						else
						{
							foreach (IOperator o in Op_List.op_list)
							{
								if (l[i].Content == o.Name)
									Operation.Push(o);
							}
						} 
						break;
					case (Lexem.Type.OpenParenthesis):
						Operation.Push(new Open());
						break;
					case (Lexem.Type.CloseParenthesis):
						{
							while (Operation.Count > 0 &&Operation.Peek().Name!="(")
							{
								ExpSingle();
							}
							Operation.Pop();
						}
						break;
					case (Lexem.Type.Variable):
						break;

				}
			}
			while (Number.Count != 1)
			{
				ExpSingle();
			}
			m.result = (DoubleValue)Number.Pop();
		}
		private void ExpSingle()
		{
			IValue[] iv = new IValue[Operation.Peek().NArgs];
			IExpression[] ie = new IExpression[Operation.Peek().NArgs];
			for (int j = iv.Length-1; j >=0; j--)
			{
				iv[j] = Number.Pop();
				ie[j] = new ConstExpression(iv[j]);
			}
			DoubleValue result = (DoubleValue)Operation.Pop().Make(ie).GetValue();
			Number.Push(result);
		}
	}
}
