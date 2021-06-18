using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreClasses;

namespace UnitTestProject1
{
	[TestClass]
	public class UT_Divide
	{
		[TestMethod]
		public void Name()
		{
			Divide d = new Divide();
			string name = d.Name;
			Assert.AreEqual("/", name);
		}

		[TestMethod]
		public void Priority()
		{
			Divide d = new Divide();
			int prior = d.Priority;
			Assert.AreEqual(50, prior);
		}

		[TestMethod]
		public void NArgs()
		{
			Divide d = new Divide();
			int args = d.NArgs;
			Assert.AreEqual(2, args);
		}

		[TestMethod]
		public void Make()
		{
			Divide m = new Divide();
			IExpression[] ie = new IExpression[2] { new ConstExpression(new DoubleValue(3)), new ConstExpression(new DoubleValue(2)) };
			DivideExpression sum = (DivideExpression)m.Make(ie);
			DoubleValue result = (DoubleValue)sum.GetValue();
			Assert.AreEqual(1.5, result.value, 1e-9);
		}
	}
}
