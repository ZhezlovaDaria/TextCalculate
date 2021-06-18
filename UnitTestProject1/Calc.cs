using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreClasses;
using System.Collections.Generic;

namespace UnitTestProject1
{
	[TestClass]
	public class UT_Calc
	{
		[TestMethod]
		public void TestNormal()
		{
			Model model = new Model("2+3");

			Parser p = new Parser();
			model.syntax_tree = p.Structure_recognize(model.origin_text);

			Calculate c = new Calculate();

			c.StackExp(model);
			Assert.AreEqual(5, model.result.value, 1e-9);

		}
		[TestMethod]
		[ExpectedException(typeof(ParseException))]
		public void TestNegative()
		{
			Model model = new Model("3+ы+3");

			Parser p = new Parser();
			model.syntax_tree = p.Structure_recognize(model.origin_text);

			Calculate c = new Calculate();

			c.StackExp(model);
			Assert.AreNotEqual(-1, model.error_position);

		}
	}
}
