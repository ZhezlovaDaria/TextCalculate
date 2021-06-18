using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreClasses;

namespace UnitTestProject1
{
	[TestClass]
	public class UT_Minus
	{
		[TestMethod]
		public void Name()
		{
			Minus m = new Minus();
			string name = m.Name;
			Assert.AreEqual("-", name);
		}

		[TestMethod]
		public void Priority()
		{
			Minus m = new Minus();
			int prior = m.Priority;
			Assert.AreEqual(20, prior);
		}

		[TestMethod]
		public void NArgs()
		{
			Minus m = new Minus();
			int args = m.NArgs;
			Assert.AreEqual(2, args);
		}

		[TestMethod]
		public void Make()
		{
			Minus m = new Minus();
			IExpression[] ie = new IExpression[2] { new ConstExpression(new DoubleValue(2)), new ConstExpression(new DoubleValue(3)) };
			SubtractionsExpression sum = (SubtractionsExpression)m.Make(ie);
			DoubleValue result = (DoubleValue)sum.GetValue();
			Assert.AreEqual(-1, result.value, 1e-9);
		}
	}
}
