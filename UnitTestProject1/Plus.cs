using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreClasses;

namespace UnitTestProject1
{
	[TestClass]
	public class UT_Plus
	{
		[TestMethod]
		public void Name()
		{
			Plus p = new Plus();
			string name = p.Name;
			Assert.AreEqual("+", name);
		}

		[TestMethod]
		public void Priority()
		{
			Plus p = new Plus();
			int prior = p.Priority;
			Assert.AreEqual(20, prior);
		}

		[TestMethod]
		public void NArgs()
		{
			Plus p = new Plus();
			int args = p.NArgs;
			Assert.AreEqual(2, args);
		}

		[TestMethod]
		public void Make()
		{
			Plus p = new Plus();
			IExpression[] ie = new IExpression[2] { new ConstExpression(new DoubleValue(2)) , new ConstExpression(new DoubleValue(3)) };
			SumExpression sum= (SumExpression)p.Make(ie);
			DoubleValue result = (DoubleValue)sum.GetValue();
			Assert.AreEqual(5, result.value, 1e-9);
		}
	}
}
