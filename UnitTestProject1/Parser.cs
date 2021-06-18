using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreClasses;
using System.Collections.Generic;

namespace UnitTestProject1
{
	[TestClass]
	public class UT_Parser
	{
		[TestMethod]
		public void SyntaxTreeTest()
		{
			Parser p = new Parser();
			List<Lexem> lexemlist=p.Structure_recognize("2+5=");
			List<Lexem> exp = new List<Lexem>();
			exp.Add(new Lexem(Lexem.Type.Number, 0, 1, "2"));
			exp.Add(new Lexem(Lexem.Type.Operator, 1, 1, "+"));
			exp.Add(new Lexem(Lexem.Type.Number, 2, 1, "5"));
			Assert.AreEqual(lexemlist, exp);

		}

		[TestMethod]
		public void FullSplit()
		{
			Parser p = new Parser();
			p.Split_full_text("2+3=\n3+5=");
			Assert.AreEqual("2+3", ModelList.modellist[0].origin_text);
			Assert.AreEqual("3+5", ModelList.modellist[1].origin_text);

		}
	}
}
