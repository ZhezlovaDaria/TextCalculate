using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CoreClasses
{
	public class Parser
	{
		private string original_text;
		private string[] current_text;
		private List<Lexem> ll=new List<Lexem>();
		public List<string> pattern_list = new List<string>()
		{
			"+", "-", "*", "/"
		};

		public void Split_full_text(string s)
		{
			original_text = s;
			ModelList.modellist.Clear();
			string[] sep = new string[1] { "\n" };
			current_text = original_text.Split(sep, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < current_text.Length; i++)
			{
				int n = current_text[i].IndexOf("=");
				if (n!=-1)
				current_text[i] = current_text[i].Remove(n);
				if (current_text[i]!="")
				ModelList.modellist.Add(new Model(current_text[i]));
			}

			for (int i = 0; i < ModelList.modellist.Count; i++)
			{
				try
				{
					ModelList.modellist[i].syntax_tree = Structure_recognize(ModelList.modellist[i].Origin_Text);
				}
				catch (ParseException e)
				{
					int d = e.position;
					ModelList.modellist[i].error_position = d;
					ModelList.modellist[i].Error_Text = e.Message;
				}
			}

		}

		public  List<Lexem>  Structure_recognize(string c)
		{
			Lexer l = new Lexer();
			ll = new List<Lexem>();
			int t = 1;
				foreach (Lexem a in l.Split(c, pattern_list))
				{
				try
				{
					ll.Add(a);
				}
				catch (ParseException e)
				{
					throw new ParseException("Ошибка", e.position, 1);
				}
				}

			return ll;
		}
	}
}

//public void Det_single_line(string s, int position)
//{
//	foreach (Lexem t in ll)
//	{

//	}


//	for (int i = 0; i < ll.Count; i--)
//	{
//		switch (ll[i].T)
//		{
//			case (Lexem.Type.Number):
//				DoubleValue d = new DoubleValue(Double.Parse(ll[i].Content));
//				break;
//			case (Lexem.Type.Operator):

//				break;
//			case (Lexem.Type.Variable): break;
//			case (Lexem.Type.OpenParenthesis): break;
//			case (Lexem.Type.CloseParenthesis): break;

//		}

//	}

//}


//for (int i =0; i<ll.Count; i--)
//{
//	if (ll[i].T == Lexem.Type.Operator)
//		{
//		foreach (IOperator o in op_list)
//		{
//			if (ll[i].Content == o.Name)
//			{
//				switch (o.NArgs)
//				{
//					case (2):
//						{
//							M.syntax_tree.Push(
//								o.Make(new ConstExpression[]
//								{ new ConstExpression(new DoubleValue(Double.Parse(ll[i-1].Content))),
//						 new ConstExpression(new DoubleValue(Double.Parse(ll[i+1].Content))) }));
//							break;
//						}
//					case (1):
//						{
//							M.syntax_tree.Push(
//								o.Make(new ConstExpression[]
//								{ new ConstExpression(new DoubleValue(Double.Parse(ll[i+1].Content))),
//								}));
//							break;
//						}
//				}
//			}
//		}
//	}


//public void Check_all_single_line(string s)
//{


//}

//public void Det_single_line(Model M)
//{
//	M.syntax_tree = Structure_recognize(original_text);


//}
//}